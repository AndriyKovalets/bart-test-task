using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Core.Inrerfaces.Repisitories;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.ContactDtos;
using TestTask.Domain.Entities;
using TestTask.Domain.Exceptions;

namespace TestTask.Core.Services
{
    internal class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<Contact> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactInfoDto> AddContactAsync(AddContactDto addContactDto)
        {
            var contact = await _contactRepository.Query()
                .FirstOrDefaultAsync(x=>x.Email == addContactDto.Email);

            if(contact != null)
            {
                throw new BadRequestHttpException("Contact with this email already exist");
            }

            var contactToAdd = _mapper.Map<Contact>(addContactDto);

            await _contactRepository.AddAsync(contactToAdd);
            await _contactRepository.SaveChangesAsync();

            return _mapper.Map<ContactInfoDto>(contactToAdd);
        }

        public async Task<List<ContactInfoDto>> GetAllContactsAsync()
        {
            var contactList = await _contactRepository.GetAllAsync();

            return _mapper.Map<List<ContactInfoDto>>(contactList);
        }

        public async Task<ContactInfoDto> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetByKeyAsync(id);

            if (contact == null)
            {
                throw new NotFoundHttpException("Contact with this id not found");
            }

            return _mapper.Map<ContactInfoDto>(contact);
        }

        public async Task<ContactInfoDto> EditContactAsync(int id, UpdateContactDto updateContactDto)
        {
            var contact = await _contactRepository.GetByKeyAsync(id);

            if (contact == null)
            {
                throw new NotFoundHttpException("Contact with this id not found");
            }

            var isEmailExist = await _contactRepository.Query()
                .AnyAsync(x => x.Email == updateContactDto.Email && x.Id != id);

            if (isEmailExist)
            {
                throw new BadRequestHttpException("Contact with this email already exist");
            }

            _mapper.Map(updateContactDto, contact);

            await _contactRepository.UpdateAsync(contact);
            await _contactRepository.SaveChangesAsync();

            return _mapper.Map<ContactInfoDto>(contact);
        }
    }
}
