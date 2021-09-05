using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScheduleNetCore.Api.CrossCutting.Middleware;
using ScheduleNetCore.Api.CrossCutting.Register;
using ScheduleNetCore.Api.DataAccess;
using ScheduleNetCore.API.Config;

namespace ScheduleNetCore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Inyectamos la conexión a la base de datos.
            services.AddDbContext<ScheduleNetCoreDBContext>(opt =>
                opt.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            IoCRegister.AddRegistration(services);
            SwaggerConfig.AddRegistration(services);

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "resourceApi1";
                });

            services.AddControllers();
 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Estas son las exepciones que viene por defecto .Net Core
                //app.UseDeveloperExceptionPage();

                SwaggerConfig.AddRegistration(app);
                //app.UseDeveloperExceptionPage();

                //Vamos a crear nuestro MiddlleWare. Nuestro manejador de excepciones.
                app.UseMiddleware<HandleErrorMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
