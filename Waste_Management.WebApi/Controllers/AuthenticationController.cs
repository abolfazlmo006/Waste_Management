using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Waste_Management.WebApi.Contracts.Services;
using Waste_Management.WebApi.DTOs.UserDto;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<Response>> Register([FromBody] RegistrationModel model)
        {
            var result = await _userService.RegisterUser(model);
            return Ok(result);
        }

        [HttpPost("Register/Supervisor")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response>> RegisterSupervisor([FromBody] RegistrationModel model)
        {
            var result = await _userService.RegisterSupervisor(model, User.Identity.Name);
            return Ok(result);
        }
        [HttpPost("Register/Municipality")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<Response>> RegisterMunicipality([FromBody] RegistrationModel model)
        {
            var result = await _userService.RegisterMunicipality(model, User.Identity.Name);
            return Ok(result);
        }
        [Authorize(Roles = "Supervisor")]
        [HttpPost("Register/Contractor")]
        public async Task<ActionResult<Response>> RegisterContractor([FromBody] RegistrationModel model)
        {
            var result = await _userService.RegisterContractor(model, User.Identity.Name);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _userService.Login(model);
            return Ok(result);
        }
    }
}
