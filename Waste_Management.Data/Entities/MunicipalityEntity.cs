namespace Waste_Management.Data.Entities
{
    public class MunicipalityEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public ICollection<SupervisorEntity> Supervisors { get; set; }
    }
}
