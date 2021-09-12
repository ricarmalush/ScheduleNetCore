using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Services
{
    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _centerRepository;

        public CenterService(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public async Task<CenterEntity> Add(CenterEntity entity)
        {
            return await _centerRepository.Add(entity);
        }

        public async Task<CenterEntity> DeleteAsync(int id)
        {
            return await _centerRepository.DeleteAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var entidad = await _centerRepository.GetById(id);
            return entidad != null ? true : false;
        }

        public async Task<bool> GetByName(CenterEntity entity)
        {
            var entidad = await _centerRepository.GetByName(entity);
            return entidad;
        }

        public async Task<CenterEntity> GetById(int idEntity)
        {
            var entidad = await _centerRepository.GetById(idEntity);
            return entidad;
        }

        public async Task<IEnumerable<CenterEntity>> GetAll()
        {
            return await _centerRepository.GetAll();
        }

        public async Task<CenterEntity> UpdateAsync(CenterEntity entity)
        {
            return await _centerRepository.UpdateAsync(entity);
        }

        public async Task<CenterEntity> UpdateActive(int identity)
        {
            return await _centerRepository.UpdateActive(identity);
        }

        public async Task<CenterEntity> UpdateDesactive(int identity)
        {
            return await _centerRepository.UpdateDesactive(identity);
        }
    }
}

