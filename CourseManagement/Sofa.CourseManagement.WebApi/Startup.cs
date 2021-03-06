﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sofa.CourseManagement.DependencyResolver;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.EntityFramework.Factory;
using Sofa.CourseManagement.EntityFramework.Seed;
using Sofa.EntityFramework.Factory;
using Sofa.EntityFramework.Seed;
using Sofa.SharedKernel;
using Sofa.CourseManagement.WebApi.Middleware;
using System;

namespace Sofa.CourseManagement.WebApi
{
    public class Startup
    {
        ContainerBuilder containerBuilder;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            containerBuilder = new ContainerBuilder();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });
            services.AddHttpClient();

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

            // Enable Swagger   
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sofa API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                     },
                        new string[] { }
                   }
                });
            });
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddResourceOwnerValidator<CustomUserOwnedPasswordValidator>();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters()
            .AddControllersAsServices();

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
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<EnableRewindableBodyStartup>();

            app.UseCors("AllowAllOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sofa Course Management API V1");
            });

            app.UseIdentityServer();
            app.UseMvc();
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
        }

        private IServiceProvider ConfigurationIoc(IServiceCollection services)
        {
            // Register the Options:
            services.AddOptions();
            // Register the Seed:
            services.AddSingleton<IDbContextSeed, DbContextSeed>();
            // Add the DbContextOptions:
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Sofa.CourseManagement.EntityFramework"))
                .EnableSensitiveDataLogging()
                .Options;
            services.AddSingleton(dbContextOptions);
            // Finally register the DbContextOptions:
            services.AddSingleton<ApplicationDbContextOptions>();
            // This Factory is used to create the DbContext from the custom DbContextOptions:
            services.AddSingleton<IApplicationDbContextFactory, ApplicationDbContextFactory>();
            // Finally Add the Applications DbContext:
            services.AddDbContext<ApplicationDbContext>();

            // Create an Autofac Container and push the framework services
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ServiceBusSettingProvider>().As<IServiceBusSettingProvider>();
            containerBuilder.RegisterType<Logger>().As<SharedKernel.ILogger>();
            containerBuilder.Populate(services);

            // Register your own services within Autofac
            containerBuilder.RegisterModule<RegisterEntityFramework>();
            containerBuilder.RegisterModule<RegisterRepository>();
            containerBuilder.RegisterModule<RegisterDomainServices>();
            containerBuilder.RegisterModule<RegisterServices>();
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
