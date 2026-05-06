using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Waste_Management.WebApi.Contracts.Services;
using Waste_Management.WebApi.DTOs.ExhibitorDto;

namespace Waste_Management.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExhibitorController : ControllerBase
    {
        private readonly IExhibitorService _exhibitorService;
        public ExhibitorController(IExhibitorService exhibitorService)
        {
            _exhibitorService = exhibitorService;
        }

        [HttpPost("SendRequestExhibitor")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> SendRequestExhibitor([FromBody] CreateRequestExhibitorDto dto)
        {
            var result = await _exhibitorService.SendRequestExhibitor(dto,User.Identity.Name);
            return Ok(result);
        }

        [HttpGet("GetRequestExhibitors")]
        [Authorize(Roles = "Contractor")]
        public async Task<ActionResult<List<GetRequestExhibitorsDto>>> GetRequestExhibitors()
        {
            var result = await _exhibitorService.GetRequestExhibitors();

            return Ok(result);
        }

        [HttpGet("VerifyRequestExhibitor/{Id:int}/{BoothId:int}")]
        [Authorize(Roles = "Contractor")]
        public async Task<ActionResult> VerifyRequestExhibitor(int Id, int BoothId)
        {
            var result = await _exhibitorService.VerifyRequestExhibitor(Id, BoothId,User.Identity.Name);
            return Ok(result);
        }

        [HttpGet("Exhibitor/Contractor")]
        [Authorize(Roles = "Contractor")]
        public async Task<ActionResult<List<GetExhibitorDto>>> GetExhibitorByContractor()
        {
            var result = await _exhibitorService.GetExhibitorByContractor(User.Identity.Name);
            return Ok(result);
        }

        [HttpGet("Exhibitor/Contractor/{BoothId}")]
        [Authorize(Roles = "Contractor")]
        public async Task<ActionResult<List<GetExhibitorDto>>> GetExhibitorByBooth(int BoothId)
        {
            var result = await _exhibitorService.GetExhibitorByBooth(BoothId,User.Identity.Name);
            return Ok(result);
        }

        [HttpDelete("Exhibitor/{Id}")]
        [Authorize(Roles = "Contractor")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _exhibitorService.Delete(Id);
            return NoContent();
        }
    }
}
