using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Contracts.Services
{
    public interface IServiceRepository<T> where T : class
    {
        Task<bool> Exist(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int idEntity);
        Task<T> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T> UpdateActive(int identity);
        Task<T> UpdateDesactive(int identity);
        Task<T> Add(T entity);
    }
}