using Microsoft.AspNetCore.Mvc;
using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.Application.Middleware;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientScheduleController : ControllerBase
    {
        private readonly IClientScheduleService _clientScheduleService;

        public ClientScheduleController(IClientScheduleService clientScheduleService)
        {
            _clientScheduleService = clientScheduleService;
        }

        //api/ClientSchedule/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] ClientScheduleEntity model)
        {
            var result = await _clientScheduleService.Add(model);
            return Ok(result);
        }

        //api/ClientSchedule/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clientScheduleService.DeleteAsync(id);
            return Ok(result);
        }

        //api/ClientSchedule/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clientScheduleService.GetById(id);
            return Ok(result);
        }

        //api/ClientSchedule/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clientScheduleService.GetAll();
            return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron los clientes !!" });

        }

        //api/ClientSchedule/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] ClientScheduleEntity model)
        {
            var result = await _clientScheduleService.UpdateAsync(model);
            return Ok(result);
        }

        //api/ClientSchedule/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var result = await _clientScheduleService.UpdateActive(id);
            return Ok(result);
        }

        //api/ClientSchedule/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            var result = await _clientScheduleService.UpdateDesactive(id);
            return Ok(result);
        }

    }
}
