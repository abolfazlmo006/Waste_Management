using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Waste_Management.WebApi.Contracts.Services;
using Waste_Management.WebApi.DTOs.ExhibitorDto;
using Waste_Management.WebApi.DTOs.ExhibitorDto.Validators;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Services
{
    public class ExhibitorService : IExhibitorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserEntity> _userManager;
        private readonly Waste_ManagementDbContext _context;

        public ExhibitorService(IUnitOfWork unitOfWork, UserManager<UserEntity> userManager, Waste_ManagementDbContext context)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _context = context;
        }
        public async Task<int?> GetWithIncludeId(string username, string include = null)
        {

            switch (include)
            {
                case "Contractor":
                    var u = await _context.Users.Select(u => new
                    {
                        u.Contractor.Id,
                        u.UserName
                    }).FirstOrDefaultAsync(u => u.UserName == username);
                    return u.Id;
                case "Supervisor":
                    var u2 = await _context.Users.Select(u => new
                    {
                        u.Supervisor.Id,
                        u.UserName
                    }).FirstOrDefaultAsync(u => u.UserName == username);
                    return u2.Id;
                case "Municipality":
                    var u3 = await _context.Users.Select(u => new
                    {
                        u.Municipality.Id,
                        u.UserName
                    }).FirstOrDefaultAsync(u => u.UserName == username);
                    return u3.Id;
                case "Exhibitor":
                    var u4 = await _context.Users.Select(u => new
                    {
                        u.Exhibitor.Id,
                        u.UserName
                    }).FirstOrDefaultAsync(u => u.UserName == username);
                    return u4.Id;
                default:
                    return null;
            }
        }

        private async Task<ExhibitorEntity> getByUserName(string userName)
        {
            return await _context.Exhibitors.FirstOrDefaultAsync(e => e.User.UserName == userName);
        }
        public async Task<string> VerifyRequestExhibitor(VerifyRequestExhibitorDto dto)
        {
            var re = await _context.User_Request_Exhibitors.FindAsync(dto.Id);

            if (re != null)
            {
                await _unitOfWork.Exhibitor.Add(new ExhibitorEntity()
                {
                    BoothId = dto.BoothId,
                    ContractorId = dto.ContractorId,
                    UserId = re.UserId
                });
                _context.Remove(re);
            }

            await _context.SaveChangesAsync();
            return re.UserId;
        }
        public async Task Delete(int Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Exhibitor.Id == Id);

            await _userManager.RemoveFromRoleAsync(user, "Exhibitor");

            var e = await _context.Exhibitors.FindAsync(Id);
            e.IsActive = false;

            await _context.SaveChangesAsync();
        }

        public async Task<List<GetExhibitorDto>> GetExhibitorByBooth(int BoothId, string UserName)
        {
            var user = await GetWithIncludeId(UserName, "Contractor");
            var result = await _context.Exhibitors.Select(e => new GetExhibitorDto()
            {
                ContractorId = e.ContractorId,
                Address = e.User.User_Request_Exhibitor.Address,
                Booth_Name = e.Booth.Name,
                Full_Name = e.User.Full_Name,
                Id = e.Id,
                BoothId = e.BoothId,
                IsActive = e.IsActive
            }).AsNoTrackingWithIdentityResolution().Where(e => e.BoothId == BoothId && e.ContractorId == (int)user && e.IsActive).ToListAsync();

            return result;
        }

        public async Task<List<GetExhibitorDto>> GetExhibitorByContractor(string UserName)
        {
            var user = await GetWithIncludeId(UserName, "Contractor");

            var result = await _context.Exhibitors.Select(e => new GetExhibitorDto()
            {
                ContractorId = e.ContractorId,
                Address = e.User.User_Request_Exhibitor.Address,
                Booth_Name = e.Booth.Name,
                Full_Name = e.User.Full_Name,
                Id = e.Id,
                BoothId = e.BoothId,
                IsActive = e.IsActive
            }).AsNoTrackingWithIdentityResolution().Where(e => e.ContractorId == (int)user && e.IsActive).ToListAsync();
            return result;
        }

        public async Task<List<GetRequestExhibitorsDto>> GetRequestExhibitors()
        {
            var result = await _context.User_Request_Exhibitors.Select(u => new GetRequestExhibitorsDto()
            {
                Address = u.Address,
                FullName = u.User.Full_Name,
                Id = u.Id,
                SendTime = u.SendTime,
                Success = u.IsSuccess
            }).AsNoTrackingWithIdentityResolution().Where(u => u.Success == false).ToListAsync();
            return result;
        }

        public async Task<Response> SendRequestExhibitor(CreateRequestExhibitorDto dto, string UserName)
        {
            var response = new Response();
            var Validator = new CreateRequestExhibitorDtoValidator();
            var ValidationResult = await Validator.ValidateAsync(dto);

            if (!ValidationResult.IsValid)
            {
                response.Errors = ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.SuccessFul = false;
                response.Message = "عملیات درخواست برای غرفه دار شدن با خطا مواجه شد";
                return response;
            }

            var user = await _userManager.FindByNameAsync(UserName);

            var Roles = await _userManager.GetRolesAsync(user);
            if (Roles.Count != 1)
            {
                response.Message = "خطای دسترسی";
                response.SuccessFul = false;
                return response;
            }
            await _context.User_Request_Exhibitors.AddAsync(new User_Request_Exhibitor()
            {
                UserId = user.Id,
                IsSuccess = false,
                SendTime = DateTime.Now,
                Address = dto.Address
            });
            response.Message = "عملیات درخواست با موفقیت انجام شد";
            response.SuccessFul = true;
            await _unitOfWork.Save();
            return response;
        }

        public async Task<Response> VerifyRequestExhibitor(int Id, int BoothId, string UserName)
        {
            var response = new Response();
            var userName = await _context.User_Request_Exhibitors.Select(u => new GetRequestExhibitorsDto()
            {
                Address = u.Address,
                FullName = u.User.Full_Name,
                Id = u.Id,
                SendTime = u.SendTime,
                Success = u.IsSuccess
            }).AsNoTrackingWithIdentityResolution().Where(u => u.Success == false).ToListAsync();

            var Contractor = await _context.Contractors.FirstOrDefaultAsync(c=> c.User.UserName == UserName);
            var exhibitor = await getByUserName(UserName);
            string UserId;
            if (exhibitor == null)
            {
                UserId = await VerifyRequestExhibitor(new VerifyRequestExhibitorDto()
                {
                    BoothId = BoothId,
                    Id = Id,
                    ContractorId = Contractor.Id
                });

            }
            else
            {
                exhibitor.IsActive = true;
                exhibitor.BoothId = BoothId;
                UserId = exhibitor.UserId;
                await _unitOfWork.Exhibitor.Update(exhibitor);
            }
            var user = await _userManager.FindByIdAsync(UserId);

            await _context.User_Request_Exhibitors.Where(r => r.Id == Id).ExecuteDeleteAsync();

            await _userManager.AddToRoleAsync(user, "Exhibitor");

            response.Message = "عملیات با موفقیت انجام شد";
            response.SuccessFul = true;
            return response;
        }
    }
}
