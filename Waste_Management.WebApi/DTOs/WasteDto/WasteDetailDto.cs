namespace Waste_Management.WebApi.DTOs.WasteDto
{
    public class WasteDetailDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string User_FullName { get; set; }
        public string Booth_Name { get; set; }
        public string Booth_Address { get; set; }
        public string Exhibitor_FullName { get; set; }
        public string userName { get; set; }
    }
}
