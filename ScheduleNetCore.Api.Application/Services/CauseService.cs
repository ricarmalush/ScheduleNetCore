using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Services
{
    public class CauseService : ICauseService
    {
        private readonly ICauseRepository _causeRepository;

        public CauseService(ICauseRepository causeRepository)
        {
            _causeRepository = causeRepository;
        }
        public async Task<CauseEntity> Add(CauseEntity entity)
        {
            return await _causeRepository.Add(entity);
        }

        public async Task<CauseEntity> DeleteAsync(int id)
        {
            return await _causeRepository.DeleteAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var entidad = await _causeRepository.GetById(id);
            return entidad != null ? true : false;
        }

        public async Task<bool> GetByName(CauseEntity entity)
        {
            var entidad = await _causeRepository.GetByName(entity);
            return entidad;
        }

        public async Task<CauseEntity> GetById(int idEntity)
        {
            var entidad = await _causeRepository.GetById(idEntity);
            return entidad;
        }

        public async Task<IEnumerable<CauseEntity>> GetAll()
        {
            return await _causeRepository.GetAll();
        }

        public async Task<CauseEntity> UpdateAsync(CauseEntity entity)
        {
            return await _causeRepository.UpdateAsync(entity);
        }

        public async Task<CauseEntity> UpdateActive(int identity)
        {
            return await _causeRepository.UpdateActive(identity);
        }

        public async Task <CauseEntity> UpdateDesactive(int identity)
        {
            return await _causeRepository.UpdateDesactive(identity);
        }
    }
}
