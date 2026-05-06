namespace Waste_Management.WebApi.DTOs.BoothDto
{
    public class BoothDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ContractorEntity Contractor { get; set; }
    }
}
