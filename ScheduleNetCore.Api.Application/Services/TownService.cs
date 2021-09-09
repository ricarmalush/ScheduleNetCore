using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Services
{
    public class TownService : ITownService
    {
        private readonly ITownRepository _townRepository;

        public TownService(ITownRepository townRepository)
        {
            _townRepository = townRepository;
        }

        public async Task<TownEntity> Add(TownEntity entity)
        {
            return await _townRepository.Add(entity);
        }

        public async Task<TownEntity> DeleteAsync(int id)
        {
            return await _townRepository.DeleteAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var entidad = await _townRepository.GetById(id);
            return entidad != null ? true : false;
        }

        public async Task<bool> GetByName(TownEntity entity)
        {
            var entidad = await _townRepository.GetByName(entity);
            return entidad;
        }

        public async Task<TownEntity> GetById(int idEntity)
        {
            var entidad = await _townRepository.GetById(idEntity);
            return entidad;
        }

        public async Task<IEnumerable<TownEntity>> GetAll()
        {
            return await _townRepository.GetAll();
        }

        public async Task<TownEntity> UpdateAsync(TownEntity entity)
        {
            return await _townRepository.UpdateAsync(entity);
        }

        public async Task<TownEntity> UpdateActive(int identity)
        {
            return await _townRepository.UpdateActive(identity);
        }

        public async Task<TownEntity> UpdateDesactive(int identity)
        {
            return await _townRepository.UpdateDesactive(identity);
        }
    }
}
