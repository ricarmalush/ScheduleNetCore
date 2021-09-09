using Microsoft.EntityFrameworkCore;
using ScheduleNetCore.Api.Application.Middleware;
using ScheduleNetCore.Api.DataAccess.Contracts;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.DataAccess.Repositories
{
    public class CauseRepository : ICauseRepository
    {
        private readonly IScheduleNetCoreDBContext _scheduleNetCoreDBContext;

        public CauseRepository(IScheduleNetCoreDBContext scheduleNetCoreDBContext)
        {
            _scheduleNetCoreDBContext = scheduleNetCoreDBContext;
        }

        public async Task<CauseEntity> Add(CauseEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    bool existe = await GetByName(entity);

                    if (!existe)
                    {
                        await _scheduleNetCoreDBContext.Cause.AddAsync(entity);
                        await _scheduleNetCoreDBContext.SaveChangesAsync();

                        return entity;
                    }
                    else
                    {
                        throw new HandlerException(HttpStatusCode.Found, new { mensaje = "La causa ya está registrado" });
                    }
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<CauseEntity> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo eliminar la causa" });
            }
            else
            {
                var entity = await GetById(id);

                _scheduleNetCoreDBContext.Cause.Remove(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> Exist(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar la compañía" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Company.FirstOrDefaultAsync(x => x.CompanyId == id);
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

        public async Task<bool> GetByName(CauseEntity entity)
        {
            if (entity.CauseName != null)
            {
                var result = await _scheduleNetCoreDBContext.Cause.FirstOrDefaultAsync(x => x.CauseName == entity.CauseName && x.ClientScheduleId == entity.ClientScheduleId);
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

        public async Task<CauseEntity> GetById(int idEntity)
        {
            if (idEntity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar la causa" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Cause.FirstOrDefaultAsync(x => x.CauseId == idEntity);
                return result;
            }
        }

        public async Task<IEnumerable<CauseEntity>> GetAll()
        {
            return await _scheduleNetCoreDBContext.Cause.ToListAsync();
        }

        public async Task<CauseEntity> UpdateAsync(CauseEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.CauseId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    var UpdateEnity = _scheduleNetCoreDBContext.Cause.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();

                    return UpdateEnity.Entity;
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<CauseEntity> UpdateActive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo activar la causa"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = true;
                _scheduleNetCoreDBContext.Cause.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<CauseEntity> UpdateDesactive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo desactivar la causa"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = false;
                _scheduleNetCoreDBContext.Cause.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}
