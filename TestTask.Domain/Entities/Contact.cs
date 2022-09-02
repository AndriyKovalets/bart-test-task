namespace TestTask.Domain.Entities
{
    internal class Contact: IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<Account>? Accounts { get; set; }
    }
}
