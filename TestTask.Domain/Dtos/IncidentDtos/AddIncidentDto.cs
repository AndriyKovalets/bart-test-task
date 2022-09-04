namespace TestTask.Domain.Dtos.IncidentDtos
{
    public class AddIncidentDto
    {
        public string Description { get; set; } = null!;
        public int AccountId { get; set; }
    }
}
