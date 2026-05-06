using Waste_Management.WebApi.DTOs.BoothDto;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Contracts.Services
{
    public interface IBoothService
    {
        Task<List<BoothListDto>> GetAll();
        Task<BoothDetailDto> Get(int Id);
        Task<Response> Add(CreateBoothDto dto, string UserName);
        Task<Response> Update(UpdateBoothDto dto);
        Task Delete(int Id);
        Task<List<BoothListDto>> GetByContractor(string UserName);
    }
}
