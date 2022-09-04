using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Core.Inrerfaces.Repisitories;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.AccountDtos;
using TestTask.Domain.Entities;
using TestTask.Domain.Exceptions;

namespace TestTask.Core.Services
{
    internal class AccountService
        : BaseService<AddAccountDto, AccountInfoDto, UpdateAccountDto, int, Account>, IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public AccountService(
            IRepository<Account> accountRepository,
            IRepository<Contact> contactRepository,
            IMapper mapper)
            : base(accountRepository, mapper)
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public override async Task<AccountInfoDto> AddAsync(AddAccountDto addDto)
        {
            await CheckAccountNameAsync(addDto.Name);

            await CheckContactAsync(addDto.ContactId);

            var accountToAdd = _mapper.Map<Account>(addDto);

            await _accountRepository.AddAsync(accountToAdd);
            await _accountRepository.SaveChangesAsync();

            return _mapper.Map<AccountInfoDto>(accountToAdd);
        }

        public override async Task<AccountInfoDto> UpdateAsync(int id, UpdateAccountDto updateDto)
        {
            var account = await _accountRepository.GetByKeyAsync(id);

            if (account is null)
            {
                throw new NotFoundHttpException("Account with this id not found");
            }

            if(updateDto.Name is not null)
                await CheckAccountNameAsync(updateDto.Name, id);

            if (updateDto.ContactId is not null)
                await CheckContactAsync(updateDto.ContactId.Value);


            _mapper.Map(updateDto, account);

            await _accountRepository.UpdateAsync(account);
            await _accountRepository.SaveChangesAsync();

            return _mapper.Map<AccountInfoDto>(account);
        }

        private async Task CheckContactAsync(int contactId)
        {
            var isContactExist = await _contactRepository.Query()
                .AnyAsync(x => x.Id == contactId);

            if (!isContactExist)
            {
                throw new NotFoundHttpException("Contact with this id not found");
            }
        }

        private async Task CheckAccountNameAsync(string accountName, int? accountId = null)
        {
            var isNameExist = await _accountRepository.Query()
               .AnyAsync(x => x.Name == accountName && (!accountId.HasValue || x.Id != accountId));

            if (isNameExist)
            {
                throw new BadRequestHttpException("Account with this name already exist");
            }
        }
    }
}
