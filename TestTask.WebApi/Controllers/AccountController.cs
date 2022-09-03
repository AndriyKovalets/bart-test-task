using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.AccountDtos;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController
        : BaseController<AddAccountDto, AccountInfoDto, UpdateAccountDto, int, IAccountService>
    {
        public AccountController(IAccountService accountService)
            : base(accountService)
        {

        }
    }
}
