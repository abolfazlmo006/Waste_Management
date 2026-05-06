using Waste_Management.WebApi.DTOs.UserDto;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Contracts.Services
{
    public interface IUserService
    {
        Task<Response> RegisterUser(RegistrationModel model);
        Task<Response> RegisterSupervisor(RegistrationModel model,string UserName);
        Task<Response> RegisterMunicipality(RegistrationModel model, string UserName);
        Task<Response> RegisterContractor(RegistrationModel model, string UserName);
        Task<object> Login(LoginModel model);
    }
}
