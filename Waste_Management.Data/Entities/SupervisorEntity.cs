global using System.ComponentModel.DataAnnotations.Schema;

namespace Waste_Management.Data.Entities
{
    public class SupervisorEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public int MunicipalityId { get; set; }
        public MunicipalityEntity Municipality { get; set; }
        public ICollection<ContractorEntity> Contractors { get; set; }

    }
}
