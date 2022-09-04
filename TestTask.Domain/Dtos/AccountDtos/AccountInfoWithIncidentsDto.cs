using TestTask.Domain.Dtos.IncidentDtos;

namespace TestTask.Domain.Dtos.AccountDtos
{
    public class AccountInfoWithIncidentsDto: AccountInfoDto
    {
        public List<IncidentInfoDto>? Incidents { get; set; }
    }
}
