using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sofa.EntityFramework.Factory;
using Sofa.EntityFramework.Seed;
using Sofa.SharedKernel;
using Sofa.Teacher.Bots;
using Sofa.Teacher.DependencyResolver;
using Sofa.Teacher.EntityFramework.Context;
using Sofa.Teacher.EntityFramework.Factory;
using Sofa.Teacher.EntityFramework.Seed;
using System;

namespace Sofa.Teacher
{
    public class Startup
    {
        ContainerBuilder containerBuilder;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            containerBuilder = new ContainerBuilder();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // ********************
            // Setup CORS
            // ********************            
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddHttpClient();
            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            // Create the storage we'll be using for User and Conversation state.
            // (Memory is great for testing purposes - examples of implementing storage with Azure Blob Storage or Cosmos DB are below).
            var storage = new MemoryStorage();

            // Create the User state passing in the storage layer.
            var userState = new UserState(storage);
            services.AddSingleton(userState);

            // Create the Conversation state passing in the storage layer.
            var conversationState = new ConversationState(storage);
            services.AddSingleton(conversationState);

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, TeacherBot>();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddResourceOwnerValidator<CustomUserOwnedPasswordValidator>();

            var identityAuthority = Configuration.GetValue<string>("identityAuthority");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = identityAuthority;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api";
                });

            // Disable Validation in Controller
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            return ConfigurationIoc(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("SiteCorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseIdentityServer();

            app.UseMvc();
        }

        private IServiceProvider ConfigurationIoc(IServiceCollection services)
        {
            // Register the Options:
            services.AddOptions();
            // Register the Seed:
            services.AddSingleton<IDbContextSeed, DbContextSeed>();
            // Add the DbContextOptions:
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("BotConnection"), x => x.MigrationsAssembly("Sofa.Teacher.EntityFramework"))
                .Options;
            services.AddSingleton(dbContextOptions);
            // Finally register the DbContextOptions:
            services.AddSingleton<ApplicationDbContextOptions>();
            // This Factory is used to create the DbContext from the custom DbContextOptions:
            services.AddSingleton<IApplicationDbContextFactory, ApplicationDbContextFactory>();
            // Finally Add the Applications DbContext:
            services.AddDbContext<ApplicationDbContext>();

            services.AddSingleton<ILogger, Logger>();
            // Create an Autofac Container and push the framework services
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ServiceBusSettingProvider>().As<IServiceBusSettingProvider>();

            containerBuilder.Populate(services);

            // Register your own services within Autofac
            containerBuilder.RegisterModule<RegisterEntityFramework>();
            containerBuilder.RegisterModule<RegisterRepository>();
            containerBuilder.RegisterModule<RegisterDomainServices>();
            containerBuilder.RegisterModule<RegisterServices>();
            containerBuilder.RegisterModule<RegisterServiceBus>();

            // Build the container and return an IServiceProvider from Autofac
            var container = containerBuilder.Build();

            // ********************
            // Start Bus
            // ********************
            var busControl = container.Resolve<IBusControl>();
            busControl.Start();

            return container.Resolve<IServiceProvider>();
        }
    }
}
