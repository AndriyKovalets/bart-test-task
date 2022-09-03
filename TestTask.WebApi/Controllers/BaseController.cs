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
        public virtual async Task<IActionResult> AddAsync([FromBody] TAddDto addtDto)
        {
            var entity = await _service.AddAsync(addtDto);

            return Ok(entity);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactInfoDto>>> GetAllAsync()
        {
            var entityList = await _service.GetAllAsync();

            return Ok(entityList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfoDto>> GetAsync([FromRoute] TKey id)
        {
            var entity = await _service.GetByKeyAsync(id);

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactInfoDto>> UpdateAsync(
            [FromRoute] TKey id,
            [FromBody] TUndateDto updateContactDto)
        {
            var entity = await _service.UpdateAsync(id, updateContactDto);

            return Ok(entity);
        }
    }
}
