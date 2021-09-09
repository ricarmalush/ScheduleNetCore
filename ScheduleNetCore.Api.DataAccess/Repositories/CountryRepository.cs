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
    public class CountryRepository : ICountryRepository
    {
        private readonly IScheduleNetCoreDBContext _scheduleNetCoreDBContext;

        public CountryRepository(IScheduleNetCoreDBContext scheduleNetCoreDBContext)
        {
            _scheduleNetCoreDBContext = scheduleNetCoreDBContext;
        }
        public async Task<CountryEntity> Add(CountryEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.CountryId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    bool existe = await GetByName(entity);

                    if (!existe)
                    {
                        await _scheduleNetCoreDBContext.Country.AddAsync(entity);
                        await _scheduleNetCoreDBContext.SaveChangesAsync();

                        return entity;
                    }
                    else
                    {
                        throw new HandlerException(HttpStatusCode.Found, new { mensaje = "El país ya está registrado" });
                    }
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<CountryEntity> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo eliminar el País" });
            }
            else
            {
                var entity = await GetById(id);

                _scheduleNetCoreDBContext.Country.Remove(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> GetByName(CountryEntity entity)
        {
            if (entity.CountryName != null)
            {
                var result = await _scheduleNetCoreDBContext.Country.FirstOrDefaultAsync(x => x.CountryName == entity.CountryName && x.ClientScheduleId == entity.ClientScheduleId);
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
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar el País" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Country.FirstOrDefaultAsync(x => x.CountryId == id);
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

        public async Task<CountryEntity> GetById(int idEntity)
        {
            if (idEntity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar el País" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Country.FirstOrDefaultAsync(x => x.CountryId == idEntity);
                return result;
            }
        }

        public async Task<IEnumerable<CountryEntity>> GetAll()
        {
            return await _scheduleNetCoreDBContext.Country.ToListAsync();
        }

        public async Task<CountryEntity> UpdateAsync(CountryEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.CountryId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    var UpdateEnity = _scheduleNetCoreDBContext.Country.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();

                    return UpdateEnity.Entity;
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<CountryEntity> UpdateActive(int identity)
        {
            
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo activar el País"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = true;
                _scheduleNetCoreDBContext.Country.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            } 
        }

        public async Task<CountryEntity> UpdateDesactive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo desactivar el País"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = false;
                _scheduleNetCoreDBContext.Country.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

    }
}
