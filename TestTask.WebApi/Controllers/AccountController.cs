using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.AccountDtos;
using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController
        : BaseController<AddAccountDto, AccountInfoDto, UpdateAccountDto, int, IAccountService>
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
            : base(accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{key}/full-info")]
        public async Task<ActionResult<ContactInfoDto>> GetAccountFullInfoAsync([FromRoute] int key)
        {
            var entity = await _accountService.GetFullInfoByKeyAsync(key);

            return Ok(entity);
        }

        [HttpGet("{key}/incidents")]
        public async Task<ActionResult<ContactInfoDto>> GetInsidentListAsync([FromRoute] int key)
        {
            var entity = await _accountService.GetInsidentListAsync(key);

            return Ok(entity);
        }
    }
}
