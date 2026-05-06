global using AutoMapper;
global using Waste_Management.WebApi.DTOs.BoothDto.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Waste_Management.WebApi.Contracts.Services;
using Waste_Management.WebApi.DTOs.BoothDto;
using Waste_Management.WebApi.Services.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Waste_Management.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Contractor")]
    public class BoothController : ControllerBase
    {
        private readonly IBoothService _boothService;
        public BoothController(IBoothService boothService)
        {
            _boothService = boothService;
        }

        // GET: api/<BoothController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<BoothListDto>>> Get()
        {
            var booths = await _boothService.GetAll();
            return Ok(booths);
        }

        // GET api/<BoothController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BoothDetailDto>> Get(int id)
        {
            var booth = await _boothService.Get(id);
            return Ok(booth);
        }

        // POST api/<BoothController>
        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] CreateBoothDto dto)
        {
            var result = await _boothService.Add(dto, User.Identity.Name);
            return Ok(result);
        }

        // PUT api/<BoothController>/5
        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] UpdateBoothDto dto)
        {
            var result = await _boothService.Update(dto);
            return Ok(result);
        }

        // DELETE api/<BoothController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _boothService.Delete(id);
            return NoContent();
        }
        // GET: api/<BoothController>/Contractor
        [HttpGet("Contractor")]
        public async Task<ActionResult<List<BoothListDto>>> GetByContractor()
        {
            var booths = await _boothService.GetByContractor(User.Identity.Name);
            return Ok(booths);
        }
    }
}
