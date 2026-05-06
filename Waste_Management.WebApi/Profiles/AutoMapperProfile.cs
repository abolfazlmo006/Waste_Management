using AutoMapper;
using Waste_Management.WebApi.DTOs.BoothDto;
using Waste_Management.WebApi.DTOs.WasteDto;

namespace Waste_Management.WebApi.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BoothDetailDto, BoothEntity>().ReverseMap();
            CreateMap<BoothListDto, BoothEntity>().ReverseMap();
            CreateMap<CreateBoothDto, BoothEntity>().ReverseMap();
            CreateMap<UpdateBoothDto, BoothEntity>().ReverseMap();
            CreateMap<WasteLIstDto, WasteEntity>().ReverseMap();
            CreateMap<CreateWateDto, WasteEntity>().ReverseMap();
        }
    }
}
