namespace TestTask.Domain.Entities
{
    internal class Incident : IBaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Account Account { get; set; } = null!;
        public int AccountId { get; set; }
    }
}
