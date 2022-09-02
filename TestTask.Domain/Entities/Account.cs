namespace TestTask.Domain.Entities
{
    internal class Account: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;

        public Contact Contact { get; set; } = null!;
        public int ContactId { get; set; }
    }
}
