using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.Application.Contracts.Services
{
    public interface ICenterService : IServiceRepository<CenterEntity>
    {
    }
}
