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
    public class CentersController : ControllerBase
    {
        private readonly ICenterService _centerService;

        public CentersController(ICenterService causeService)
        {
            _centerService = causeService;
        }

        //api/Centers/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] CenterEntity model)
        {
            var result = await _centerService.Add(model);
            return Ok(result);
        }

        //api/Centers/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _centerService.DeleteAsync(id);
            return Ok(result);
        }

        //api/Centers/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _centerService.GetById(id);
            return Ok(result);
        }

        //api/Centers/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _centerService.GetAll();
            return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron los centros !!" });
        }

        //api/Centers/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CenterEntity model)
        {
            var result = await _centerService.UpdateAsync(model);
            return Ok(result);
        }

        //api/Centers/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var result = await _centerService.UpdateActive(id);
            return Ok(result);
        }

        //api/Centers/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            var result = await _centerService.UpdateDesactive(id);
            return Ok(result);
        }

    }
}
