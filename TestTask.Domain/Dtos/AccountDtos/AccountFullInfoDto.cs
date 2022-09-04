using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.Domain.Dtos.AccountDtos
{
    public class AccountFullInfoDto : AccountInfoDto
    {
        public ContactInfoDto? Contact { get; set; }
    }
}
