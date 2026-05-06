global using Waste_Management.Data.Entities;
using Waste_Management.WebApi.Contracts.Repository;

namespace Waste_Management.WebApi.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<BoothEntity> Booth { get; }
        IGenericRepository<ContractorEntity> Contractor { get; }
        IGenericRepository<ExhibitorEntity> Exhibitor { get; }
        IGenericRepository<MunicipalityEntity> Municipality { get; }
        IGenericRepository<SupervisorEntity> Supervisor { get; }
        IGenericRepository<UserEntity> User { get; }
        IGenericRepository<WasteEntity> Waste { get; }
        IGenericRepository<User_Request_Exhibitor> UserRequestExhibitor { get; }
        Task Save();
    }
}
