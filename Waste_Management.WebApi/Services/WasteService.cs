using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Waste_Management.WebApi.Contracts.Services;
using Waste_Management.WebApi.DTOs.WasteDto;
using Waste_Management.WebApi.DTOs.WasteDto.Validators;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Services
{
    public class WasteService : IWasteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private readonly Waste_ManagementDbContext _context;
        public WasteService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<UserEntity> userManager, Waste_ManagementDbContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _context = context;
        }

        public async Task<Response> Add(CreateWateDto dto , string UserName)
        {
            var response = new Response();
            var Validator = new CreateWateDtoValidator();
            var ValidationResult = await Validator.ValidateAsync(dto);

            if (ValidationResult.IsValid == false)
            {
                response.Errors = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                response.SuccessFul = false;
                response.Message = "عملیات ایجاد پسماند با شکست مواجه  شد";
                return response;
            }
            var user = await _userManager.FindByNameAsync(dto.User_UserName);
            var exhibitor = await _context.Exhibitors.FirstOrDefaultAsync(e => e.User.UserName == UserName);
            if (user == null)
            {
                response.SuccessFul = false;
                response.Message = "چنین کاربری در سامانه وجود ندارد";
                return response;
            }
            var waste = _mapper.Map<WasteEntity>(dto);
            waste.UserId = user.Id;
            waste.ExhibitorId = exhibitor.Id;
            waste.BoothId = exhibitor.BoothId;
            await _unitOfWork.Waste.Add(waste);

            response.SuccessFul = true;
            response.Message = "عملیات ایجاد پسماند با موفقیت انجام شد";
            return response;
        }

        public async Task Delete(int Id)
        {
            await _context.Wastes.Where(w => w.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<WasteDetailDto> Get(int Id , string UserName)
        {
            return await _context.Wastes.Select(w => new WasteDetailDto()
            {
                Id = w.Id,
                Type = w.Type,
                Value = w.Value,
                User_FullName = w.User.Full_Name,
                Booth_Name = w.Booth.Name,
                Booth_Address = w.Booth.Address,
                Exhibitor_FullName = w.Exhibitor.User.Full_Name,
                userName = w.User.UserName
            }).FirstOrDefaultAsync(w => w.Id == Id && w.userName == UserName);
        }

        public async Task<List<WasteLIstDto>> GetByExhibitor(string UserName)
        {
            var Wastes = await _context.Wastes.Where(w => w.Exhibitor.User.UserName == UserName).ToListAsync();

            var map = _mapper.Map<List<WasteLIstDto>>(Wastes);

            return map;
        }

        public async Task<WasteDetailDto> GetByExhibitorDetail(int Id, string UserName)
        {
            return await _context.Wastes.Select(w => new WasteDetailDto()
            {
                Id = w.Id,
                Type = w.Type,
                Value = w.Value,
                User_FullName = w.User.Full_Name,
                Booth_Name = w.Booth.Name,
                Booth_Address = w.Booth.Address,
                Exhibitor_FullName = w.Exhibitor.User.Full_Name,
                userName = w.Exhibitor.User.UserName
            }).FirstOrDefaultAsync(w => w.Id == Id && w.userName == UserName);
        }

        public async Task<List<WasteLIstDto>> GetByUser(string UserName)
        {
            var Wastes = await _context.Wastes.Where(w => w.User.UserName == UserName).ToListAsync();

            var map = _mapper.Map<List<WasteLIstDto>>(Wastes);
            return map;
        }

        public async Task<Response> Update(WasteLIstDto dto)
        {
            var response = new Response();
            var Validator = new UpdateWasteDtoValidator();
            var ValidationResult = await Validator.ValidateAsync(dto);

            if (ValidationResult.IsValid == false)
            {
                response.Errors = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                response.Message = "عملیات ویرایش پسماند با شکست موجه شد";
                response.SuccessFul = false;
                return response;
            }
            var waste = _mapper.Map<WasteEntity>(dto);
            await _unitOfWork.Waste.Update(waste);

            response.Message = "عملیات ویرایش پسماند با موفقیت انجام شد";
            response.SuccessFul = true;
            return response;

        }
    }
}
