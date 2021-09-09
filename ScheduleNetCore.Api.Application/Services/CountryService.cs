using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<CountryEntity> Add(CountryEntity entity)
        {
            return await _countryRepository.Add(entity);
        }

        public async Task<CountryEntity> DeleteAsync(int id)
        {
            return await _countryRepository.DeleteAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var entidad = await _countryRepository.GetById(id);
            return entidad != null ? true : false;
        }

        public async Task<bool> GetByName(CountryEntity entity)
        {
            var entidad = await _countryRepository.GetByName(entity);
            return entidad;
        }
        public async Task<IEnumerable<CountryEntity>> GetAll()
        {
            return await _countryRepository.GetAll();
        }

        public async Task<CountryEntity> GetById(int idEntity)
        {
            var entidad = await _countryRepository.GetById(idEntity);
            return entidad;
        }

        public async Task<CountryEntity> UpdateActive(int identity)
        {
            return await _countryRepository.UpdateActive(identity);
        }

        public async Task<CountryEntity> UpdateAsync(CountryEntity entity)
        {
            return await _countryRepository.UpdateAsync(entity);
        }

        public async Task<CountryEntity> UpdateDesactive(int identity)
        {
            return await _countryRepository.UpdateDesactive(identity);
        }
    }
}
