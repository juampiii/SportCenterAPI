using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SportCenterAPI.Config
{
    /// <summary>
    /// Allow to register and config the Swagger Service
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Add the Swagger Service to the service container
        /// </summary>
        /// <param name="services">The list of the app services</param>
        /// <returns>The list of the services updated</returns>
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            var basepath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basepath, "SportCenter.Api.xml");

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Sport Center API V1",
                    Version = "V1",
                    Description = "API Rest to manage courts booking"
                });
            });

            return services;
        }

        /// <summary>
        /// Add the Swagger Service to the service container
        /// </summary>
        /// <param name="app">The class to configure the services</param>
        /// <returns>the <paramref name="app"/> with the configuration of the Swagger Service updated</returns>
        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "Sport Center API V1"));

            return app;
        }
    }
}
