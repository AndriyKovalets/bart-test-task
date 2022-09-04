using TestTask.Domain.Dtos.AccountDtos;

namespace TestTask.Domain.Dtos.IncidentDtos
{
    public class IncidentFullInfoDto: IncidentInfoDto
    {
        public AccountFullInfoDto? Account { get; set; }
    }
}
