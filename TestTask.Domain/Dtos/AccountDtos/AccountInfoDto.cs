using TestTask.Domain.Entities;

namespace TestTask.Domain.Dtos.AccountDtos
{
    public class AccountInfoDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ContactId { get; set; }
    }
}
