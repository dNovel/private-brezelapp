using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Brezelapp.Controllers.V1;
using Brezelapp.Db;
using Brezelapp.Services;
using Brezelapp.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

namespace Brezelapp
{
    public class Startup
    {
        private ApiVersion apiVersion;

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
            // Application Insights configuration
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
                    c.SwaggerDoc("v1", new Info { Title = "BrezelAppApi", Version = "v1" });
                });
            }

            // Add DbContext
            services.AddDbContext<BrezelMSSqlContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Brezelapp"))
            );

            // Add the transients and singletons
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IBrezelService, BrezelService>();

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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }


            app.UseMvc();
        }
    }
}
