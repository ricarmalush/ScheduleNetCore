using Microsoft.Extensions.DependencyInjection;
using ScheduleNetCore.Api.Application.ApiCaller;
using ScheduleNetCore.Api.Application.Configuration;
using ScheduleNetCore.Api.Application.Contracts.ApiCaller;
using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.Application.Services;
using ScheduleNetCore.Api.DataAccess;
using ScheduleNetCore.Api.DataAccess.Contracts;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using ScheduleNetCore.Api.DataAccess.Repositories;

namespace ScheduleNetCore.Api.CrossCutting.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);

            return services;
        }

        public static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IClientScheduleService, ClientScheduleService>();

            return services;
        }

        public static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IScheduleNetCoreDBContext, ScheduleNetCoreDBContext>();
            services.AddTransient<IClientScheduleRepository, ClientScheduleRepository>();

            return services;
        }

        public static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            services.AddTransient<IAppConfig,AppConfig>();
            services.AddTransient<IApiCaller, ApiCaller>();

            return services;
        }
    }
}
