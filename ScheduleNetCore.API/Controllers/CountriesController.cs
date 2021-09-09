using Microsoft.AspNetCore.Mvc;
using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.Application.Middleware;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        //api/Countries/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] CountryEntity model)
        {
            var result = await _countryService.Add(model);
            return Ok(result);
        }

        //api/Countries/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _countryService.DeleteAsync(id);
            return Ok(result);
        }

        //api/Countries/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _countryService.GetById(id);
            return Ok(result);
        }

        //api/Countries/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _countryService.GetAll();
            return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron los países !!" });
        }

        //api/Countries/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CountryEntity model)
        {
            var result = await _countryService.UpdateAsync(model);
            return Ok(result);
        }

        //api/Countries/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var result = await _countryService.UpdateActive(id);
            return Ok(result);
        }

        //api/Countries/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            var result = await _countryService.UpdateDesactive(id);
            return Ok(result);
        }

    }
}
