using Waste_Management.WebApi.DTOs.WasteDto;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Contracts.Services
{
    public interface IWasteService
    {
        Task<List<WasteLIstDto>> GetByUser(string UserName);
        Task<WasteDetailDto> Get(int Id, string UserName);
        Task<Response> Add(CreateWateDto dto, string UserName);
        Task<Response> Update(WasteLIstDto dto);
        Task Delete(int Id);
        Task<List<WasteLIstDto>> GetByExhibitor(string UserName);
        Task<WasteDetailDto> GetByExhibitorDetail(int Id, string UserName);
    }
}
