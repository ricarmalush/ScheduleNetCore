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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyervice;

        public CompaniesController(ICompanyService companyervice)
        {
            _companyervice = companyervice;
        }

        //api/Companies/AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] CompanyEntity model)
        {
            var result = await _companyervice.Add(model);
            return Ok(result);
        }

        //api/Companies/DeleteAsync/{id}
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _companyervice.DeleteAsync(id);
            return Ok(result);
        }

        //api/Companies/GetById?id=1
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _companyervice.GetById(id);
            return Ok(result);
        }

        //api/Companies/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyervice.GetAll();
            return result != null ? Ok(result) : throw new HandlerException(HttpStatusCode.BadRequest, new { mensaje = "!! No se encontraron las compañías !!" });

        }

        //api/Companies/UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CompanyEntity model)
        {
            var result = await _companyervice.UpdateAsync(model);
            return Ok(result);
        }

        //api/Companies/UpdateActive/{id}
        [HttpPut("UpdateActive")]
        public async Task<IActionResult> UpdateActive(int id)
        {
            var result = await _companyervice.UpdateActive(id);
            return Ok(result);
        }

        //api/Companies/UpdateDesactive/{id}
        [HttpPut("UpdateDesactive")]
        public async Task<IActionResult> UpdateDesactive(int id)
        {
            var result = await _companyervice.UpdateDesactive(id);
            return Ok(result);
        }

    }
}
