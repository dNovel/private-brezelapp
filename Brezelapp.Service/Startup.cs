// <copyright file="Startup.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp
{
    using AutoMapper;
    using Brezelapp.Controllers.V1;
    using Brezelapp.Db;
    using Brezelapp.Models;
    using Brezelapp.Models.Viewmodels;
    using Brezelapp.Services;
    using Brezelapp.Services.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.Configuration = configuration;
            this.HostingEnvironment = hostingEnvironment;

            this.DefaultApiVersion = new ApiVersion(1, 0);
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        public ApiVersion DefaultApiVersion { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Application Insights configuration
            if (this.HostingEnvironment.IsStaging() || this.HostingEnvironment.IsProduction())
            {
                // TODO: Implement fully
                services.AddApplicationInsightsTelemetry();
            }
            else if (this.HostingEnvironment.IsDevelopment())
            {
                // Add swagger documentation
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "BrezelAppApi", Version = "v1", Description = "This is the documentation for the Brezelapp API v1. This API can be consumed from various applications as long as authentication is properly implemented." });
                });
            }

            // Add DbContext
            services.AddDbContext<BrezelMSSqlContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultWindows")));

            // Add the transients and singletons
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IBrezelService, BrezelService>();

            // Configure AutoMapper for the ViewModel DomainModel mapping
            MapperConfiguration autoMapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<StoreRequest, Store>();
                config.CreateMap<BrezelRequest, Brezel>();
            });
            IMapper mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Add versioning
            services.AddApiVersioning(options =>
            {
                // Generic configuration
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = this.DefaultApiVersion;

                // Configure header based versioning
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");

                // Controller specific version mapping
                options.Conventions.Controller<StoresController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<BrezelsController>().HasApiVersion(new ApiVersion(1, 0));
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (this.HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Use swagger for documentation on the corresponding enpoint
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrezelApp Documentation v1");
                });
            }

            app.UseMvc();
        }
    }
}
