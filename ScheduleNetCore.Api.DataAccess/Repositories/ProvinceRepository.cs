using Microsoft.EntityFrameworkCore;
using ScheduleNetCore.Api.Application.Middleware;
using ScheduleNetCore.Api.DataAccess.Contracts;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.DataAccess.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly IScheduleNetCoreDBContext _scheduleNetCoreDBContext;

        public ProvinceRepository(IScheduleNetCoreDBContext scheduleNetCoreDBContext)
        {
            _scheduleNetCoreDBContext = scheduleNetCoreDBContext;
        }
        public async Task<ProvinceEntity> Add(ProvinceEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.CountryId <= 0 || entity.ProvinceId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    bool existe = await GetByName(entity);

                    if (!existe)
                    {
                        await _scheduleNetCoreDBContext.Province.AddAsync(entity);
                        await _scheduleNetCoreDBContext.SaveChangesAsync();

                        return entity;
                    }
                    else
                    {
                        throw new HandlerException(HttpStatusCode.Found, new { mensaje = "La provincia ya está registrado" });
                    }
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<ProvinceEntity> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo eliminar la provincia" });
            }
            else
            {
                var entity = await GetById(id);

                _scheduleNetCoreDBContext.Province.Remove(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> Exist(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar la provincia" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Province.FirstOrDefaultAsync(x => x.ProvinceId == id);
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

        public async Task<bool> GetByName(ProvinceEntity entity)
        {
            if (entity.Name != null)
            {
                var result = await _scheduleNetCoreDBContext.Province.FirstOrDefaultAsync(x => x.Name == entity.Name && x.ClientScheduleId == entity.ClientScheduleId);
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
        public async Task<ProvinceEntity> GetById(int idEntity)
        {
            if (idEntity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar la provincia" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Province.FirstOrDefaultAsync(x => x.ProvinceId == idEntity);
                return result;
            }
        }

        public async Task<IEnumerable<ProvinceEntity>> GetAll()
        {
            return await _scheduleNetCoreDBContext.Province.ToListAsync();
        }

        public async Task<ProvinceEntity> UpdateAsync(ProvinceEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.CountryId <= 0 || entity.ProvinceId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    var UpdateEnity = _scheduleNetCoreDBContext.Province.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();

                    return UpdateEnity.Entity;
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<ProvinceEntity> UpdateActive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo activar la provincia"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = true;
                _scheduleNetCoreDBContext.Province.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<ProvinceEntity> UpdateDesactive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo desactivar la provincia"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = false;
                _scheduleNetCoreDBContext.Province.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}
