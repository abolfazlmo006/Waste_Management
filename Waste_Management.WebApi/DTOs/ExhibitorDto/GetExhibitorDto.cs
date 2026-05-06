namespace Waste_Management.WebApi.DTOs.ExhibitorDto
{
    public class GetExhibitorDto
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public int ContractorId { get; set; }
        public string Address { get; set; }
        public string Booth_Name { get; set; }
        public int BoothId { get; set; }
        public bool IsActive { get; set; }
    }
}
