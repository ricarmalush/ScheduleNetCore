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
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        //api/Provinces/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] ProvinceEntity model)
        {
            var result = await _provinceService.Add(model);
            return Ok(result);
        }

        //api/Provinces/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _provinceService.DeleteAsync(id);
            return Ok(result);
        }

        //api/Provinces/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _provinceService.GetById(id);
            return Ok(result);
        }

        //api/Provinces/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _provinceService.GetAll();
            return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron las provincias !!" });

        }

        //api/Provinces/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProvinceEntity model)
        {
            var result = await _provinceService.UpdateAsync(model);
            return Ok(result);
        }

        //api/Provinces/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var result = await _provinceService.UpdateActive(id);
            return Ok(result);
        }

        //api/Provinces/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            var result = await _provinceService.UpdateDesactive(id);
            return Ok(result);
        }

    }
}
