using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Waste_Management.WebApi.Contracts;
using Waste_Management.WebApi.Contracts.Services;
using Waste_Management.WebApi.DTOs.UserDto;
using Waste_Management.WebApi.Services.Base;

namespace Waste_Management.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IConfiguration _configuration;
        private readonly Waste_ManagementDbContext _context;
        public UserService(IUnitOfWork unitOfWork, UserManager<UserEntity> userManager, IConfiguration configuration, Waste_ManagementDbContext context)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _configuration = configuration;
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

        public async Task<object> Login(LoginModel model)
        {
            
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var response = new Response();
                response.Message = "اطلاعات اشتباه است";
                response.SuccessFul = false;
                return response;
            }
                

            var roleClaim = new List<Claim>();
            var roles = await _userManager.GetRolesAsync(user);

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaim.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }.Union(roleClaim);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured")));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return new LoginResponse
            {
                JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        public async Task<Response> RegisterContractor(RegistrationModel model, string UserName)
        {
            var response = new Response();
            var existingUser = await _userManager.FindByNameAsync(model.Username);

            if (existingUser != null)
            {
                response.Message = "کاربری با این مشخصات قبلاً ثبت شده است";
                response.SuccessFul = false;
                return response;
            }

            var newUser = new UserEntity
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                var u = await GetWithIncludeId(UserName, "Supervisor");
                if (u != null)
                {
                    newUser.Contractor = await _unitOfWork.Contractor.Add(new ContractorEntity()
                    {
                        UserId = newUser.Id,
                        SupervisorId = (int)u
                    });
                    await _userManager.UpdateAsync(newUser);

                }

                await _userManager.AddToRolesAsync(newUser, new List<string>()
                {
                    "User","Contractor"
                });
                response.Message = "عملیات افزودن شهرداری با موفقیت انجام شد";
                response.SuccessFul = true;
                return response;
            }
            else
            {
                response.Errors = result.Errors.Select(e => e.Description).ToList();
                response.Message = "عملیات با شکست مواجه شد";
                response.SuccessFul = false;
                return response;
            }
        }

        public async Task<Response> RegisterMunicipality(RegistrationModel model, string UserName)
        {
            var response = new Response();
            var existingUser = await _userManager.FindByNameAsync(model.Username);

            if (existingUser != null)
            {
                response.Message = "کاربری با این مشخصات قبلاً ثبت شده است";
                response.SuccessFul = false;
                return response;
            }

            var newUser = new UserEntity
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                var u = await _userManager.FindByNameAsync(UserName);
                if (u != null)
                {

                    newUser.Municipality = await _unitOfWork.Municipality.Add(new MunicipalityEntity()
                    {
                        UserId = newUser.Id
                    });
                    await _userManager.UpdateAsync(newUser);

                }

                await _userManager.AddToRolesAsync(newUser, new List<string>()
                {
                    "User","Admin"
                });
                response.Message = "عملیات افزودن شهرداری با موفقیت انجام شد";
                response.SuccessFul = true;
                return response;
            }
            else
            {
                response.Errors = result.Errors.Select(e => e.Description).ToList();
                response.Message = "عملیات با شکست مواجه شد";
                response.SuccessFul = false;
                return response;
            }
        }

        public async Task<Response> RegisterSupervisor(RegistrationModel model, string UserName)
        {
            var response = new Response();
            var existingUser = await _userManager.FindByNameAsync(model.Username);

            if (existingUser != null)
            {
                response.Message = "کاربری با این مشخصات قبلاً ثبت شده است";
                response.SuccessFul = false;
                return response;
            }

            var newUser = new UserEntity
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                var u = await GetWithIncludeId(UserName, "Municipality");
                if (u != null)
                {
                    newUser.Supervisor = await _unitOfWork.Supervisor.Add(new SupervisorEntity()
                    {
                        UserId = newUser.Id,
                        MunicipalityId = (int)u
                    });
                    await _userManager.UpdateAsync(newUser);

                }

                await _userManager.AddToRolesAsync(newUser, new List<string>()
                {
                    "User","Supervisor"
                });
                response.Message = "عملیات افزودن ناظر شهرداری با موفقیت انجام شد";
                response.SuccessFul = true;
                return response;
            }
            else
            {
                response.Errors = result.Errors.Select(e => e.Description).ToList();
                response.Message = "عملیات با شکست مواجه شد";
                response.SuccessFul = false;
                return response;
            }
        }

        public async Task<Response> RegisterUser(RegistrationModel model)
        {
            var response = new Response();
            var existingUser = await _userManager.FindByNameAsync(model.Username);

            if (existingUser != null)
            {
                response.Message = "کاربری با این مشخصات قبلاً ثبت شده است";
                response.SuccessFul = false;
                return response;
            }
                

            var newUser = new UserEntity
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);


            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "User");

                response.Message = "عملیات افزودن کاربر با موفقیت انجام شد";
                response.SuccessFul = true;
                return response;
            }
            else
            {
                response.Errors = result.Errors.Select(e => e.Description).ToList();
                response.Message = "عملیات با شکست مواجه شد";
                response.SuccessFul = false;
                return response;
            }
        }
    }
}
