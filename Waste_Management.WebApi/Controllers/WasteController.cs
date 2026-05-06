using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Waste_Management.WebApi.Contracts.Services;
using Waste_Management.WebApi.DTOs.WasteDto;
using Waste_Management.WebApi.Services.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Waste_Management.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WasteController : ControllerBase
    {
        private readonly IWasteService _wasteService;
        public WasteController(IWasteService wasteService)
        {
            _wasteService = wasteService;
        }

        // GET: api/<WasteController>/User
        [HttpGet("User")]
        public async Task<ActionResult<List<WasteLIstDto>>> GetByUser()
        {
            var wastes = await _wasteService.GetByUser(User.Identity.Name);
            return Ok(wastes);
        }

        // GET api/<WasteController>/User/5
        [HttpGet("User/{id}")]
        public async Task<ActionResult<WasteDetailDto>> Get(int id)
        {
            var waste = await _wasteService.Get(id,User.Identity.Name);
            return Ok(waste);
        }

        // POST api/<WasteController>
        [HttpPost]
        [Authorize(Roles = "Exhibitor")]
        public async Task<ActionResult<Response>> Post([FromBody] CreateWateDto dto)
        {
            var result = await _wasteService.Add(dto, User.Identity.Name);
            return Ok(result);
        }

        // PUT api/<WasteController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Exhibitor")]
        public async Task<ActionResult<Response>> Put([FromBody] WasteLIstDto dto)
        {
            var result = await _wasteService.Update(dto);
            return Ok(result);
        }

        // DELETE api/<WasteController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Exhibitor")]
        public async Task<ActionResult> Delete(int id)
        {
            await _wasteService.Delete(id);
            return NoContent();
        }


        // GET: api/<WasteController>/Exhibitor
        [HttpGet("Exhibitor")]
        [Authorize(Roles = "Exhibitor")]
        public async Task<ActionResult<List<WasteLIstDto>>> GetByExhibitor()
        {
            var wastes = await _wasteService.GetByExhibitor(User.Identity.Name);
            return Ok(wastes);
        }


        // GET: api/<WasteController>/Exhibitor/5
        [HttpGet("Exhibitor/{id}")]
        [Authorize(Roles = "Exhibitor")]
        public async Task<ActionResult<WasteDetailDto>> GetWasteByExhibitor(int id)
        {
            var waste = await _wasteService.GetByExhibitorDetail(id, User.Identity.Name);
            return Ok(waste);
        }
    }
}
