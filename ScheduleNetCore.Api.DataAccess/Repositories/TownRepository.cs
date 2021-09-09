using Microsoft.EntityFrameworkCore;
using ScheduleNetCore.Api.Application.Middleware;
using ScheduleNetCore.Api.DataAccess.Contracts;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.DataAccess.Repositories
{
    public class TownRepository : ITownRepository
    {
        private readonly IScheduleNetCoreDBContext _scheduleNetCoreDBContext;

        public TownRepository(IScheduleNetCoreDBContext scheduleNetCoreDBContext)
        {
            _scheduleNetCoreDBContext = scheduleNetCoreDBContext;
        }
        public async Task<TownEntity> Add(TownEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.TownId <= 0 || entity.ProvinceId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    bool existe = await GetByName(entity);

                    if (!existe)
                    {
                        await _scheduleNetCoreDBContext.Town.AddAsync(entity);
                        await _scheduleNetCoreDBContext.SaveChangesAsync();

                        return entity;
                    }
                    else
                    {
                        throw new HandlerException(HttpStatusCode.Found, new { mensaje = "El pueblo ya está registrado" });
                    }
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<TownEntity> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo eliminar el pueblo" });
            }
            else
            {
                var entity = await GetById(id);

                _scheduleNetCoreDBContext.Town.Remove(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> GetByName(TownEntity entity)
        {
            if (entity.Name != null)
            {
                var result = await _scheduleNetCoreDBContext.Town.FirstOrDefaultAsync(x => x.Name == entity.Name && x.ClientScheduleId == entity.ClientScheduleId);
                if (result == null)
                {
                    return false;//No está registrado
                }
                else
                {
                    return true;//Esta registrado
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }
        public async Task<bool> Exist(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar el Pueblo" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Town.FirstOrDefaultAsync(x => x.TownId == id);
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<TownEntity> GetById(int idEntity)
        {
            if (idEntity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar el pueblo" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Town.FirstOrDefaultAsync(x => x.TownId == idEntity);
                return result;
            }
        }

        public async Task<IEnumerable<TownEntity>> GetAll()
        {
            return await _scheduleNetCoreDBContext.Town.ToListAsync();
        }

        public async Task<TownEntity> UpdateAsync(TownEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.TownId <= 0 || entity.ProvinceId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    var UpdateEnity = _scheduleNetCoreDBContext.Town.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();

                    return UpdateEnity.Entity;
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<TownEntity> UpdateActive(int identity)
        {

            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo activar el pueblo"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = true;
                _scheduleNetCoreDBContext.Town.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<TownEntity> UpdateDesactive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo desactivar el Pueblo"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = false;
                _scheduleNetCoreDBContext.Town.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

    }
}
