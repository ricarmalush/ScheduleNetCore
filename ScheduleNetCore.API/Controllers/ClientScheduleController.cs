using Microsoft.AspNetCore.Mvc;
using ScheduleNetCore.Api.Application.Configuration;
using ScheduleNetCore.Api.Application.Contracts.ApiCaller;
using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.CrossCutting.Middleware;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientScheduleController : ControllerBase
    {
        private readonly IClientScheduleService _clientScheduleService;
        private readonly IApiCaller _apiCaller;
        private readonly IAppConfig _apiConfig;

        public ClientScheduleController(IClientScheduleService clientScheduleService, IApiCaller apiCaller, IAppConfig apiConfig)
        {
            _clientScheduleService = clientScheduleService;
            _apiCaller = apiCaller;
            _apiConfig = apiConfig;
        }

        //api/ClientSchedule/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var seconds = _apiConfig.ServiceUrl;

                var result = await _clientScheduleService.Get(id);
                return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraro el cliente !!" });
            }
            catch (Exception ex)
            {
                throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = ex.Message});
            }
        }

        //api/ClientSchedule/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _clientScheduleService.GetAll();
                return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron los clientes !!" });
            }
            catch (Exception ex)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = ex.Message });
            }
        }

        //api/ClientSchedule/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] ClientScheduleEntity model)
        {
            try
            {
                var result = await _clientScheduleService.Add(model);
                return Ok(result);
            }
            catch (Exception)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo crear el cliente" });
            }
        }

        //api/ClientSchedule/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] ClientScheduleEntity model)
        {
            try
            {
                var result = await _clientScheduleService.UpdateAsync(model);
                return Ok(result);
            }
            catch (Exception)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo actualizar el Cliente" });
            }
        }

        //api/ClientSchedule/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _clientScheduleService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo eliminar el Cliente" });
            }
        }

        //api/ClientSchedule/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            try
            {
                var result = await _clientScheduleService.UpdateActive(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo activar el Cliente" });
            }
        }

        //api/ClientSchedule/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            try
            {
                var result = await _clientScheduleService.UpdateDesactive(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw new HandlerException(HttpStatusCode.NotFound, new { mensaje = "No se pudo desactivar el Cliente" });
            }
        }


    }
}
