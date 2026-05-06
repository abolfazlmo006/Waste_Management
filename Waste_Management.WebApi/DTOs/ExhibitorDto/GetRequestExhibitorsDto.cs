namespace Waste_Management.WebApi.DTOs.ExhibitorDto
{
    public class GetRequestExhibitorsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool Success { get; set; }
        public DateTime SendTime { get; set; }
    }
}
