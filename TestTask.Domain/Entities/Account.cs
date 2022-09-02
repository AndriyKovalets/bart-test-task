namespace TestTask.Domain.Entities
{
    public class Account: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;

        public Contact Contact { get; set; } = null!;
        public int ContactId { get; set; }

        public ICollection<Incident>? Incidents { get; set; }
    }
}
