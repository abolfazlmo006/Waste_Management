namespace Waste_Management.Data.Entities
{
    public class WasteEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public int ExhibitorId { get; set; }
        public ExhibitorEntity Exhibitor { get; set; }
        public int BoothId { get; set; }
        public BoothEntity Booth { get; set; }
    }
}
