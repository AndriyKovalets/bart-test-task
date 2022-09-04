using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.IncidentDtos;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController :
        BaseController<AddIncidentDto, IncidentInfoDto, UpdateIncidentDto, string, IIncidentService>
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
            : base(incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpPost("full-info")]
        public async Task<IActionResult> AddIncidentFullInfoAsync([FromBody] AddIncidentFullInfoDto addDto)
        {
            var entity = await _incidentService.AddIncidentFullInfoAsync(addDto);

            return Ok(entity);
        }

        [HttpGet("{key}/full-info")]
        public async Task<IActionResult> GetIncidentFullInfoAsync([FromBody] string key)
        {
            var entity = await _incidentService.GetIncidentFullInfoAsync(key);

            return Ok(entity);
        }
    }
}
