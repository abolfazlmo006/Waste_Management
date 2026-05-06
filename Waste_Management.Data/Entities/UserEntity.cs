using Microsoft.AspNetCore.Identity;

namespace Waste_Management.Data.Entities
{
    public class UserEntity : IdentityUser
    {
        public int Age { get; set; }
        public string Full_Name { get; set; }
        public MunicipalityEntity? Municipality { get; set; }
        public SupervisorEntity? Supervisor { get; set; }
        public ContractorEntity? Contractor { get; set; }
        public ExhibitorEntity? Exhibitor { get; set; }
        public User_Request_Exhibitor? User_Request_Exhibitor { get; set; }
        public ICollection<WasteEntity>? Wastes { get; set; }
    }
}
