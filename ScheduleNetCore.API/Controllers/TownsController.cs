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
    public class TownsController : ControllerBase
    {
        private readonly ITownService _townService;

        public TownsController(ITownService townService)
        {
            _townService = townService;
        }

        //api/Towns/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] TownEntity model)
        {
            var result = await _townService.Add(model);
            return Ok(result);
        }

        //api/Towns/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _townService.DeleteAsync(id);
            return Ok(result);
        }

        //api/Towns/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _townService.GetById(id);
            return Ok(result);
        }

        //api/Towns/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _townService.GetAll();
            return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron los pueblos !!" });

        }

        //api/Towns/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] TownEntity model)
        {
            var result = await _townService.UpdateAsync(model);
            return Ok(result);
        }

        //api/Towns/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var result = await _townService.UpdateActive(id);
            return Ok(result);
        }

        //api/Towns/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            var result = await _townService.UpdateDesactive(id);
            return Ok(result);
        }

    }
}
