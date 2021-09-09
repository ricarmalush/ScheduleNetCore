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
    public class ClientScheduleRepository : IClientScheduleRepository
    {
        private readonly IScheduleNetCoreDBContext _scheduleNetCoreDBContext;

        public ClientScheduleRepository(IScheduleNetCoreDBContext scheduleNetCoreDBContext)
        {
            _scheduleNetCoreDBContext = scheduleNetCoreDBContext;
        }

        public async Task<ClientScheduleEntity> Add(ClientScheduleEntity entity)
        {
            if(entity != null)
            {
                bool existe = await GetByName(entity);

                if(!existe)
                {
                    await _scheduleNetCoreDBContext.ClientSchedule.AddAsync(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();

                    return entity;
                }
                else
                {
                    throw new HandlerException(HttpStatusCode.Found, new { mensaje = "El cliente ya está registrado" });
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<ClientScheduleEntity> DeleteAsync(int id)
        {
            if(id <=0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo eliminar el Cliente" });
            }
            else
            {
                var entity = await GetById(id);

                _scheduleNetCoreDBContext.ClientSchedule.Remove(entity);
                await _scheduleNetCoreDBContext.SaveChangesAsync();
                return entity;
            }    
        }

        public async Task<bool> GetByName(ClientScheduleEntity entity)
        {
            if (entity.ClientName != null)
            {
                var result = await _scheduleNetCoreDBContext.ClientSchedule.FirstOrDefaultAsync(x => x.ClientName == entity.ClientName);
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
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar el Cliente" });
            }
            else
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
        }

        public async Task<ClientScheduleEntity> GetById(int idEntity)
        {
            if (idEntity <= 0)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo encontrar el Cliente" });
            }
            else
            {
                var result = await _scheduleNetCoreDBContext.ClientSchedule.FirstOrDefaultAsync(x => x.ClientScheduleId == idEntity);
                return result;
            } 
        }

        public async Task<IEnumerable<ClientScheduleEntity>> GetAll()
        {
            return await _scheduleNetCoreDBContext.ClientSchedule.ToListAsync();
        }

        public async Task<ClientScheduleEntity> UpdateAsync(ClientScheduleEntity entity)
        {
            if (entity != null)
            {
                if (entity.ClientScheduleId <= 0)
                {
                    throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
                }
                else
                {
                    var UpdateEnity = _scheduleNetCoreDBContext.ClientSchedule.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();

                    return UpdateEnity.Entity;
                }
            }
            else
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "Los datos suministrados no son correctos." });
            }
        }

        public async Task<ClientScheduleEntity> UpdateActive(int identity)
        {
            {if (identity <= 0)
                {
                    throw new HandlerException(HttpStatusCode.NotFound, new
                    {
                        mensaje = "No se pudo activar el Cliente"
                    });
                }
                else
                {
                    var entity = await GetById(identity);
                    entity.Low = true;
                    _scheduleNetCoreDBContext.ClientSchedule.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();
                    return entity;
                }
            }   
        }

        public async Task<ClientScheduleEntity> UpdateDesactive(int identity)
        {
            {if (identity <= 0)
                {
                    throw new HandlerException(HttpStatusCode.NotFound, new
                    {
                        mensaje = "No se pudo desactivar el Cliente"
                    });
                }
                else
                {
                    var entity = await GetById(identity);
                    entity.Low = false;
                    _scheduleNetCoreDBContext.ClientSchedule.Update(entity);
                    await _scheduleNetCoreDBContext.SaveChangesAsync();
                    return entity;
                }
            }  
        }

    }
}
