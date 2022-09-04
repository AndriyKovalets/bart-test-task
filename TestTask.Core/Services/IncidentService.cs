using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Core.Inrerfaces.Repisitories;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.IncidentDtos;
using TestTask.Domain.Entities;
using TestTask.Domain.Exceptions;

namespace TestTask.Core.Services
{
    internal class IncidentService
        : BaseService<AddIncidentDto, IncidentInfoDto, UpdateIncidentDto, string, Incident>, IIncidentService
    {
        private readonly IRepository<Incident> _incidentRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public IncidentService(
            IRepository<Incident> incidentRepository,
            IRepository<Account> accountRepository,
            IRepository<Contact> contactRepository,
            IMapper mapper)
            : base(incidentRepository, mapper)
        {
            _incidentRepository = incidentRepository;
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public override async Task<IncidentInfoDto> AddAsync(AddIncidentDto addDto)
        {
            await CheckAccountIdAsync(addDto.AccountId);

            var incidentToAdd = _mapper.Map<Incident>(addDto);

            await _incidentRepository.AddAsync(incidentToAdd);
            await _incidentRepository.SaveChangesAsync();

            return _mapper.Map<IncidentInfoDto>(incidentToAdd);
        }

        public async Task<IncidentFullInfoDto> AddIncidentFullInfoAsync(AddIncidentFullInfoDto addDto)
        {
            var account = await _accountRepository.Query()
                .Include(x => x.Contact)
                .FirstOrDefaultAsync(x => x.Name == addDto.AccountName);

            if(account is null)
            {
                throw new NotFoundHttpException("Account with this name not found");
            }

            await CheckConntactEmailAsync(addDto.ContactEmail);

            var updateContact = _mapper.Map<Contact>(addDto);
            _mapper.Map(account.Contact, updateContact);

            await _accountRepository.UpdateAsync(account);

            var incidentToAdd = new Incident()
            {
                Description = addDto.IncidentDescription,
                AccountId = account.Id
            };

            await _incidentRepository.AddAsync(incidentToAdd);
            await _incidentRepository.SaveChangesAsync();

            return _mapper.Map<IncidentFullInfoDto>(incidentToAdd);
        }

        public override async Task<IncidentInfoDto> UpdateAsync(string key, UpdateIncidentDto updateDto)
        {
            var incident = await _incidentRepository.GetByKeyAsync(key);

            if(incident is null)
            {
                throw new NotFoundHttpException("Incident with this id not found");
            }

            if(updateDto.AccountId.HasValue)
            await CheckAccountIdAsync(updateDto.AccountId.Value);

            _mapper.Map(updateDto, incident);

            await _incidentRepository.UpdateAsync(incident);
            await _incidentRepository.SaveChangesAsync();

            return _mapper.Map<IncidentInfoDto>(incident);
        }

        private async Task CheckAccountIdAsync(int accountId)
        {
            var isAccountExist = await _accountRepository.Query()
                .AnyAsync(x=>x.Id == accountId);

            if(!isAccountExist)
            {
                throw new NotFoundHttpException("Account with this id not found");
            }
        }

        private async Task CheckConntactEmailAsync(string email)
        {
            var isEmailExist = await _contactRepository.Query()
                .AnyAsync(x => x.Email == email);

            if (!isEmailExist)
            {
                throw new NotFoundHttpException("Contact email not found");
            }
        }
    }
}
