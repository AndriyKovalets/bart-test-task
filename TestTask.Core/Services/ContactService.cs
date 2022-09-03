using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Core.Inrerfaces.Repisitories;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.ContactDtos;
using TestTask.Domain.Entities;
using TestTask.Domain.Exceptions;

namespace TestTask.Core.Services
{
    internal class ContactService
        : BaseService<AddContactDto, ContactInfoDto, UpdateContactDto, int, Contact>, IContactService
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<Contact> contactRepository, IMapper mapper)
            :base(contactRepository, mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public override async Task<ContactInfoDto> AddAsync(AddContactDto addContactDto)
        {
            await CheckEmailAsync(addContactDto.Email);

            var contactToAdd = _mapper.Map<Contact>(addContactDto);

            await _contactRepository.AddAsync(contactToAdd);
            await _contactRepository.SaveChangesAsync();

            return _mapper.Map<ContactInfoDto>(contactToAdd);
        }

        public override async Task<ContactInfoDto> UpdateAsync(int id, UpdateContactDto updateDto)
        {
            var contact = await _contactRepository.GetByKeyAsync(id);

            if (contact is null)
            {
                throw new NotFoundHttpException("Contact with this id not found");
            }

            if(updateDto.Email is not null)
                await CheckEmailAsync(updateDto.Email, id);

            _mapper.Map(updateDto, contact);

            await _contactRepository.UpdateAsync(contact);
            await _contactRepository.SaveChangesAsync();

            return _mapper.Map<ContactInfoDto>(contact);
        }

        private async Task CheckEmailAsync(string email, int? id = null)
        {
            var isEmailExist = await _contactRepository.Query()
                .AnyAsync(x => x.Email == email &&(!id.HasValue || x.Id != id));

            if (isEmailExist)
            {
                throw new BadRequestHttpException("Contact with this email already exist");
            }
        }
    }
}
