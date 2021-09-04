using Microsoft.Extensions.Configuration;

namespace ScheduleNetCore.Api.Application.Configuration
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Con la expresión lambda => Asignamos variables a una sola linea
        public int MaxTrys => int.Parse(_configuration.GetSection("Polly:MaxTrys").Value);

        public int SecondToWait => int.Parse(_configuration.GetSection("Polly:TimeDelay").Value);

        public string ServiceUrl => _configuration.GetSection("ServiceUrl:Url").Value;
    }
}
