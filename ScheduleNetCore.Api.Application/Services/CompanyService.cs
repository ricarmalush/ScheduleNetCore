using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyEntity> Add(CompanyEntity entity)
        {
            return await _companyRepository.Add(entity);
        }

        public async Task<CompanyEntity> DeleteAsync(int id)
        {
            return await _companyRepository.DeleteAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var entidad = await _companyRepository.GetById(id);
            return entidad != null ? true : false;
        }

        public async Task<bool> GetByName(CompanyEntity entity)
        {
            var entidad = await _companyRepository.GetByName(entity);
            return entidad;
        }

        public async Task<IEnumerable<CompanyEntity>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<CompanyEntity> GetById(int idEntity)
        {
            var entidad = await _companyRepository.GetById(idEntity);
            return entidad;
        }
        public async Task<CompanyEntity> UpdateAsync(CompanyEntity entity)
        {
            return await _companyRepository.UpdateAsync(entity);
        }


        public async Task<CompanyEntity> UpdateActive(int identity)
        {
            return await _companyRepository.UpdateActive(identity);
        }

        public async Task<CompanyEntity> UpdateDesactive(int identity)
        {
            return await _companyRepository.UpdateDesactive(identity);
        }
    }
}
