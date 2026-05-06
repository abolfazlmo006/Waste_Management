global using Waste_Management.WebApi.Services.Repository;
using Microsoft.AspNetCore.Identity;
using Waste_Management.Data;
using Waste_Management.WebApi.Contracts;
using Waste_Management.WebApi.Contracts.Repository;

namespace Waste_Management.WebApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private Waste_ManagementDbContext _context;
        private readonly UserManager<UserEntity> _userManager;
        public UnitOfWork(Waste_ManagementDbContext context, UserManager<UserEntity> userManager)
        {
            _context = context;
            _userManager = userManager;
            Booth = new GenericRepository<BoothEntity>(_context);
            Contractor = new GenericRepository<ContractorEntity>(_context);
            Exhibitor = new GenericRepository<ExhibitorEntity>(_context);
            Municipality = new GenericRepository<MunicipalityEntity> (_context);
            Supervisor = new GenericRepository<SupervisorEntity> (_context);
            User = new GenericRepository<UserEntity>(_context);
            Waste = new GenericRepository<WasteEntity>(_context);
            UserRequestExhibitor = new GenericRepository<User_Request_Exhibitor>(_context);
        }
        public IGenericRepository<BoothEntity> Booth { get; private set; }
        public IGenericRepository<ContractorEntity> Contractor { get; private set;}
        public IGenericRepository<ExhibitorEntity> Exhibitor { get; private set;}
        public IGenericRepository<MunicipalityEntity> Municipality { get; private set;}
        public IGenericRepository<SupervisorEntity> Supervisor { get; private set;}
        public IGenericRepository<UserEntity> User { get; private set;}
        public IGenericRepository<WasteEntity> Waste { get; private set;}
        public IGenericRepository<User_Request_Exhibitor> UserRequestExhibitor { get; private set; }


        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
