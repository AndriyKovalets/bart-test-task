namespace TestTask.Domain.Dtos.IncidentDtos
{
    public class IncidentInfoDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int AccountId { get; set; }
    }
}
