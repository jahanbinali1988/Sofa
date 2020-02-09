﻿using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sofa.Identity.DependencyInjection;
using Sofa.Identity.EntityFramework.Context;
using Sofa.Identity.EntityFramework.Factory;
using Sofa.Identity.EntityFramework.Seed;
using Sofa.SharedKernel;
using StructureMap;
using System;

namespace Sofa.Identity.WebAPI
{
    public class Startup
    {
        Container container;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddResourceOwnerValidator<CustomUserOwnedPasswordValidator>();

            services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();

            return ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ********************
            // Start Bus
            // ********************
            var busControl = container.GetInstance<IBusControl>();
            busControl.Start();

            app.UseMvc();
            app.UseIdentityServer();
        }

        [Obsolete]
        public IServiceProvider ConfigureIoC(IServiceCollection services)
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

            container = new Container();
            
            container.Configure(config =>
            {
                config.For<IConfiguration>().Use(Configuration);

                config.For<ILogger>().Use<Logger>();
                var allRegistry = RegistryProvider.GetAllRegistry();

                foreach (var registry in allRegistry)
                {
                    config.AddRegistry(registry);
                }
            });

            var serviceBusSettingsProvider = new ServiceBusSettingProvider(Configuration);
            container.Configure(config =>
            {
                config.AddRegistry(new ServiceBusRegistry(serviceBusSettingsProvider, container));
                //Populate the container using the service collection
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
