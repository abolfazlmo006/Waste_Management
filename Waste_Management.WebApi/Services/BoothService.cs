global using Waste_Management.Data;
global using Waste_Management.WebApi.Contracts;
global using Waste_Management.WebApi.Contracts.Services;
global using Waste_Management.WebApi.Services.Base;
using Microsoft.EntityFrameworkCore;
using Waste_Management.WebApi.DTOs.BoothDto;

namespace Waste_Management.WebApi.Services
{
    public class BoothService : IBoothService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Waste_ManagementDbContext _context;
        public BoothService(IUnitOfWork unitOfWork, IMapper mapper, Waste_ManagementDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        private async Task<ContractorEntity> getContractorByUserName(string UserName)
        {
            return await _context.Contractors.FirstOrDefaultAsync(c => c.User.UserName == UserName);
        }
        public async Task<Response> Add(CreateBoothDto dto , string UserName)
        {
            var response = new Response();
            var Validator = new CreateBoothDtoValidator();
            var ValidationResult = await Validator.ValidateAsync(dto);

            if (ValidationResult.IsValid == false)
            {
                response.Errors=ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                response.SuccessFul = false;
                response.Message = "عملیات افزودن غرفه با شکست مواجه شد";
                return response;
            }

            var contractor = await getContractorByUserName(UserName);
            var map = _mapper.Map<BoothEntity>(dto);
            map.ContractorId = contractor.Id;
            await _unitOfWork.Booth.Add(map);
            
            response.SuccessFul = true;
            response.Message = "عملیات افزودن غرفه با موفقیت انجام شد";
            return response;
        }

        public async Task Delete(int Id)
        {
            await _context.Booths.Where(b => b.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<BoothDetailDto> Get(int Id)
        {
            var booth = await _unitOfWork.Booth.Get(Id);
            var map = _mapper.Map<BoothDetailDto>(booth);
            return map;
        }

        public async Task<List<BoothListDto>> GetAll()
        {
            var booths = await _unitOfWork.Booth.GetAll();
            var map = _mapper.Map<List<BoothListDto>>(booths);
            return map;
        }

        public async Task<List<BoothListDto>> GetByContractor(string UserName)
        {
            var contractor = await getContractorByUserName(UserName);

            var booths = await _context.Booths.AsNoTrackingWithIdentityResolution().Where(b => b.ContractorId == contractor.Id).ToListAsync();

            var map = _mapper.Map<List<BoothListDto>>(booths);

            return map;
        }

        public async Task<Response> Update(UpdateBoothDto dto)
        {
            var response = new Response();
            var Validator = new UpdateBoothDtoValidator();
            var ValidationResult = await Validator.ValidateAsync(dto);

            if (ValidationResult.IsValid == false)
            {
                response.Errors = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                response.SuccessFul = false;
                response.Message = "عملیات ویرایش غرفه با شکست مواجه شد";
                return response;
            }
            var map = _mapper.Map<BoothEntity>(dto);
            await _unitOfWork.Booth.Update(map);

            response.SuccessFul = true;
            response.Message = "عملیات ویرایش غرفه با موفقیت انجام شد";
            return response;
        }
    }
}
