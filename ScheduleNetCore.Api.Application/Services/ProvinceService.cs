using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<ProvinceEntity> Add(ProvinceEntity entity)
        {
            return await _provinceRepository.Add(entity);
        }

        public async Task<ProvinceEntity> DeleteAsync(int id)
        {
            return await _provinceRepository.DeleteAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var entidad = await _provinceRepository.GetById(id);
            return entidad != null ? true : false;
        }

        public async Task<bool> GetByName(ProvinceEntity entity)
        {
            var entidad = await _provinceRepository.GetByName(entity);
            return entidad;
        }

        public async Task<IEnumerable<ProvinceEntity>> GetAll()
        {
            return await _provinceRepository.GetAll();
        }

        public async Task<ProvinceEntity> GetById(int idEntity)
        {
            var entidad = await _provinceRepository.GetById(idEntity);
            return entidad;
        }

        public async Task<ProvinceEntity> UpdateActive(int identity)
        {
            return await _provinceRepository.UpdateActive(identity);
        }

        public async Task<ProvinceEntity> UpdateAsync(ProvinceEntity entity)
        {
            return await _provinceRepository.UpdateAsync(entity);
        }

        public async Task<ProvinceEntity> UpdateDesactive(int identity)
        {
            return await _provinceRepository.UpdateDesactive(identity);
        }
    }
}
