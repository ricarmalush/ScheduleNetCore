using ScheduleNetCore.Api.Application.Configuration;
using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Services
{
    public class ClientScheduleService : IClientScheduleService
    {
        //Por convención la barra baja _ es una variable privada.
        private readonly IClientScheduleRepository _clientScheduleRepository;
        //private readonly IAppConfig _appConfig;

        //Inyectamos el registro del repositorio.
        public ClientScheduleService(IClientScheduleRepository clientScheduleRepository)
        {
            _clientScheduleRepository = clientScheduleRepository;
            //_appConfig = appConfig;
        }

        public async Task<ClientScheduleEntity> Add(ClientScheduleEntity entity)
        {
            return await _clientScheduleRepository.Add(entity);
        }

        public async Task<ClientScheduleEntity> DeleteAsync(int id)
        {
            return await _clientScheduleRepository.DeleteAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var entidad = await _clientScheduleRepository.GetById(id);
            return entidad != null ? true : false;
        }

        public async Task<ClientScheduleEntity> GetById(int idEntity)
        {
            var entidad = await _clientScheduleRepository.GetById(idEntity);
            return entidad;
        }

        public async Task<IEnumerable<ClientScheduleEntity>> GetAll()
        {
            return await _clientScheduleRepository.GetAll();
        }

        public async Task<ClientScheduleEntity> UpdateAsync(ClientScheduleEntity entity)
        {
            return await _clientScheduleRepository.UpdateAsync(entity);
        }

        public async Task<ClientScheduleEntity> UpdateActive(int identity)
        {
            return await _clientScheduleRepository.UpdateActive(identity);
        }

        public async Task<ClientScheduleEntity> UpdateDesactive(int identity)
        {
            return await _clientScheduleRepository.UpdateDesactive(identity);
        }
    }
}
