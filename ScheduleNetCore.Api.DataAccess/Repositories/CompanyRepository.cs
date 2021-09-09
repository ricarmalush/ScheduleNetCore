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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IScheduleNetCoreDBContext _scheduleNetCoreDBContext;

        public CompanyRepository(IScheduleNetCoreDBContext scheduleNetCoreDBContext)
        {
            _scheduleNetCoreDBContext = scheduleNetCoreDBContext;
        }
        public async Task<CompanyEntity> Add(CompanyEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0 || entity.CompanyId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    bool existe = await GetByName(entity);

                    if (!existe)
                    {
                        await _scheduleNetCoreDBContext.Company.AddAsync(entity);
                        await _scheduleNetCoreDBContext.SaveChangesAsync();

                        return entity;
                    }
                    else
                    {
                        throw new HandlerException(HttpStatusCode.Found, new { mensaje = "La compañía ya está registrado" });
                    }
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<CompanyEntity> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo eliminar la compañía" });
            }
            else
            {
                var entity = await GetById(id);

                _scheduleNetCoreDBContext.Company.Remove(entity);
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

        public async Task<bool> GetByName(CompanyEntity entity)
        {
            if (entity.CompanyName != null)
            {
                var result = await _scheduleNetCoreDBContext.Company.FirstOrDefaultAsync(x => x.CompanyName == entity.CompanyName && x.ClientScheduleId == entity.ClientScheduleId);
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
        public async Task<CompanyEntity> GetById(int idEntity)
        {
            if (idEntity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar la compañía" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.Company.FirstOrDefaultAsync(x => x.CompanyId == idEntity);
                return result;
            }
        }

        public async Task<IEnumerable<CompanyEntity>> GetAll()
        {
            return await _scheduleNetCoreDBContext.Company.ToListAsync();
        }

        public async Task<CompanyEntity> UpdateAsync(CompanyEntity entity)
        {
            if (entity != null)
            {
                if(entity.ClientScheduleId <= 0 || entity.CompanyId <= 0 || entity.TownId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    var UpdateEnity = _scheduleNetCoreDBContext.Company.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();

                    return UpdateEnity.Entity;
                } 
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<CompanyEntity> UpdateActive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo activar la compañía"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = true;
                _scheduleNetCoreDBContext.Company.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<CompanyEntity> UpdateDesactive(int identity)
        {
            if (identity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new
                {
                    mensaje = "No se pudo desactivar la compañía"
                });
            }
            else
            {
                var entity = await GetById(identity);
                entity.Low = false;
                _scheduleNetCoreDBContext.Company.Update(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}
