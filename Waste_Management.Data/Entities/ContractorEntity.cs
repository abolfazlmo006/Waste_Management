namespace Waste_Management.Data.Entities
{
    public class ContractorEntity 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public int SupervisorId { get; set; }
        public SupervisorEntity Supervisor { get; set; }
        public ICollection<BoothEntity> Booths { get; set; }
        public ICollection<ExhibitorEntity> Exhibitors { get; set; }
    }
}
