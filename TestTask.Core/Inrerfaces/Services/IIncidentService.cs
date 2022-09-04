using TestTask.Domain.Dtos.IncidentDtos;

namespace TestTask.Core.Inrerfaces.Services
{
    public interface IIncidentService
         : IBaseService<AddIncidentDto, IncidentInfoDto, UpdateIncidentDto, string>
    {
        Task<IncidentFullInfoDto> AddIncidentFullInfoAsync(AddIncidentFullInfoDto addDto);
        Task<IncidentFullInfoDto> GetIncidentFullInfoAsync(string name);
    }
}
