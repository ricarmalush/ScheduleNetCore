using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Repositories
{
    //Interraz repositorio en el cual vamos a tener un tipo genérico que grapea el T en todos los métodos. 
    //Y especificamos que T es una clase.
    public interface IRepository<T> where T : class
    {
        Task<bool> Exist(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int idEntity);
        Task<T> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T> UpdateActive(int identity);
        Task<T> UpdateDesactive(int identity);
        Task<T> Add(T entity);
    }
}
