using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sofa.Identity.DependencyInjection;
using Sofa.Identity.EntityFramework.Context;
using Sofa.Identity.EntityFramework.Factory;
using Sofa.Identity.EntityFramework.Seed;
using Sofa.SharedKernel;
using System;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Sofa.Identity.WebAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy(
                   name: "AllowAllOrigin",
                   builder =>
                   {
                       builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                   });
            });

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters()
            .AddControllersAsServices();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddResourceOwnerValidator<CustomUserOwnedPasswordValidator>();

            services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();

            return ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigin");

            app.UseMvc();
            app.UseIdentityServer();
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            // Register the Options:
            services.AddOptions();
            // Register the Seed:
            services.AddSingleton<IDbContextSeed, DbContextSeed>();
            // Add the DbContextOptions:
            var dbContextOptions = new DbContextOptionsBuilder<SofaIdentityDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("SofaIdentity"), x => x.MigrationsAssembly("Sofa.Identity.EntityFramework"))
                .Options;
            services.AddSingleton(dbContextOptions);
            // Finally register the DbContextOptions:
            services.AddSingleton<SofaIdentityDbContextOptions>();
            // This Factory is used to create the DbContext from the custom DbContextOptions:
            services.AddSingleton<ISofaIdentityDbContextFactory, SofaIdentityDbContextFactory>();
            // Finally Add the Applications DbContext:
            services.AddDbContext<SofaIdentityDbContext>();

            // Create an Autofac Container and push the framework services
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ServiceBusSettingProvider>().As<IServiceBusSettingProvider>();
            containerBuilder.RegisterType<Logger>().As<ILogger>();
            containerBuilder.Populate(services);

            // Register your own services within Autofac
            containerBuilder.RegisterModule<RegisterDBFactory>();
            containerBuilder.RegisterModule<RegisterRepository>();
            containerBuilder.RegisterModule<RegisterService>();
            containerBuilder.RegisterModule<RegisterServiceBus>();
            containerBuilder.RegisterModule<RegisterConsumer>();

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

