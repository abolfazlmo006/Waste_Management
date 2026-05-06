namespace Waste_Management.Data.Entities
{
    public class BoothEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ContractorId { get; set; }
        public ContractorEntity Contractor { get; set; }
        public ICollection<ExhibitorEntity> Exhibitors { get; set; }
        public ICollection<WasteEntity>? Wastes { get; set; }
    }
}
