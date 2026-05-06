using Waste_Management.WebApi.DTOs.ExhibitorDto;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Contracts.Services
{
    public interface IExhibitorService
    {
        Task<Response> SendRequestExhibitor(CreateRequestExhibitorDto dto,string UserName);
        Task<List<GetRequestExhibitorsDto>> GetRequestExhibitors();
        Task<Response> VerifyRequestExhibitor(int Id, int BoothId , string UserName);
        Task<List<GetExhibitorDto>> GetExhibitorByContractor(string UserName);
        Task<List<GetExhibitorDto>> GetExhibitorByBooth(int BoothId , string UserName);
        Task Delete(int Id);
    }
}
