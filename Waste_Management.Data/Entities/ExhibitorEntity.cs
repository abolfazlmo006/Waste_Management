using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waste_Management.Data.Entities
{
    public class ExhibitorEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public int BoothId { get; set; }
        public bool IsActive { get; set; } = true;
        public BoothEntity Booth { get; set; }
        public int ContractorId { get; set; }
        public ContractorEntity Contractor { get; set; }
        public ICollection<WasteEntity> Wastes_Exhibitor { get; set; }
    }
}
