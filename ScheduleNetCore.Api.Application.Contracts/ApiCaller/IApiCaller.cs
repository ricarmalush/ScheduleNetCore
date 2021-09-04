using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Contracts.ApiCaller
{
    public interface IApiCaller
    {
        Task<T> GetServiceResponseById<T>(string controller, int id);
    }
}
