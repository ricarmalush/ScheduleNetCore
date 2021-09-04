namespace ScheduleNetCore.Api.Application.Configuration
{
    public interface IAppConfig
    {
        //{get} => solamente queremos obtener la información de la configuración 
        int MaxTrys { get; }
        int SecondToWait { get; }
        string ServiceUrl { get; }
    }
}
