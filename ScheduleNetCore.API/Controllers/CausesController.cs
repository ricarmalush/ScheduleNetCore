using Microsoft.AspNetCore.Mvc;
using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.Application.Middleware;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausesController : ControllerBase
    {
        private readonly ICauseService _causeService;

        public CausesController(ICauseService causeService)
        {
            _causeService = causeService;
        }

        //api/Causes/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] CauseEntity model)
        {
            var result = await _causeService.Add(model);
            return Ok(result);
        }

        //api/Causes/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _causeService.DeleteAsync(id);
            return Ok(result);
        }

        //api/Causes/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _causeService.GetById(id);
            return Ok(result);
        }

        //api/Causes/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _causeService.GetAll();
            return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron los clientes !!" });

        }

        //api/Causes/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CauseEntity model)
        {
            var result = await _causeService.UpdateAsync(model);
            return Ok(result);
        }

        //api/Causes/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var result = await _causeService.UpdateActive(id);
            return Ok(result);
        }

        //api/Causes/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            var result = await _causeService.UpdateDesactive(id);
            return Ok(result);
        }

    }
}
