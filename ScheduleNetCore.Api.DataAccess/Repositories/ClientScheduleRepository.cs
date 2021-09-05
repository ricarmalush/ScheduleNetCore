using Microsoft.EntityFrameworkCore;
using ScheduleNetCore.Api.DataAccess.Contracts;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.DataAccess.Repositories
{
    public class ClientScheduleRepository : IClientScheduleRepository
    {
        private readonly IScheduleNetCoreDBContext _scheduleNetCoreDBContext;

        public ClientScheduleRepository(IScheduleNetCoreDBContext scheduleNetCoreDBContext)
        {
            _scheduleNetCoreDBContext = scheduleNetCoreDBContext;
        }

        public async Task<ClientScheduleEntity> Add(ClientScheduleEntity entity)
        {
            await _scheduleNetCoreDBContext.ClientSchedule.AddAsync(entity);
            await _scheduleNetCoreDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ClientScheduleEntity> DeleteAsync(int id)
        {
            var entity = await GetById(id);

            _scheduleNetCoreDBContext.ClientSchedule.Remove(entity);
            await _scheduleNetCoreDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            var result = await _scheduleNetCoreDBContext.ClientSchedule.FirstOrDefaultAsync(x => x.ClientScheduleId == id);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ClientScheduleEntity> GetById(int idEntity)
        {
            var result = await _scheduleNetCoreDBContext.ClientSchedule.FirstOrDefaultAsync(x => x.ClientScheduleId == idEntity);
            return result;
        }

        public async Task<IEnumerable<ClientScheduleEntity>> GetAll()
        {
            return await _scheduleNetCoreDBContext.ClientSchedule.ToListAsync();
        }

        public async Task<ClientScheduleEntity> UpdateAsync(ClientScheduleEntity entity)
        {
            var UpdateEnity = _scheduleNetCoreDBContext.ClientSchedule.Update(entity);
            await _scheduleNetCoreDBContext.SaveChangesAsync();

            return UpdateEnity.Entity;
        }

        public async Task<ClientScheduleEntity> UpdateActive(int identity)
        {
            var entity = await GetById(identity);

            entity.Low = true;

            _scheduleNetCoreDBContext.ClientSchedule.Update(entity);
            await _scheduleNetCoreDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ClientScheduleEntity> UpdateDesactive(int identity)
        {
            var entity = await GetById(identity);

            entity.Low = false;
            _scheduleNetCoreDBContext.ClientSchedule.Update(entity);
            await _scheduleNetCoreDBContext.SaveChangesAsync();
            return entity;
        }

    }
}
