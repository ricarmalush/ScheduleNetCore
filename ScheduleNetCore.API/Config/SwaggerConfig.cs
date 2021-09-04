using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleNetCore.API.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            //Esta ruta es donde esta alojada nuestra aplicación.
            var basepath = AppDomain.CurrentDomain.BaseDirectory;

            //Donde esta el xmlpath que genera el proyecto.
            var xmlpath = Path.Combine(basepath, "ScheduleNetCore.API.xml");
            

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScheduleNetCore.API", Version = "v1" });
                    c.IncludeXmlComments(xmlpath);
                }
            );

            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScheduleNetCore.API v1"));

            return app;
        }

    }
}
