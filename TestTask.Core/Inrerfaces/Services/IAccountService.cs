using TestTask.Domain.Dtos.AccountDtos;

namespace TestTask.Core.Inrerfaces.Services
{
    public interface IAccountService
        : IBaseService<AddAccountDto, AccountInfoDto, UpdateAccountDto, int>
    {
    }
}
