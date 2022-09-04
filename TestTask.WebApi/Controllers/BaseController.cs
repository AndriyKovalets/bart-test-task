using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.WebApi.Controllers
{
    [ApiController]
    public abstract class BaseController<TAddDto, TInfoDto, TUndateDto, TKey, TService> : ControllerBase
        where TService: IBaseService<TAddDto, TInfoDto, TUndateDto, TKey>
    {
        private readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<IActionResult> AddAsync([FromBody] TAddDto addDto)
        {
            var entity = await _service.AddAsync(addDto);

            return Ok(entity);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactInfoDto>>> GetAllAsync()
        {
            var entityList = await _service.GetAllAsync();

            return Ok(entityList);
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<ContactInfoDto>> GetAsync([FromRoute] TKey key)
        {
            var entity = await _service.GetByKeyAsync(key);

            return Ok(entity);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult<ContactInfoDto>> UpdateAsync(
            [FromRoute] TKey key,
            [FromBody] TUndateDto updateContactDto)
        {
            var entity = await _service.UpdateAsync(key, updateContactDto);

            return Ok(entity);
        }
    }
}
