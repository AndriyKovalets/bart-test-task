using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.Core.Inrerfaces.Services
{
    public interface IContactService
    {
        Task<ContactInfoDto> AddContactAsync(AddContactDto addContactDto);
        Task<List<ContactInfoDto>> GetAllContactsAsync();
        Task<ContactInfoDto> GetContactByIdAsync(int Id);
        Task<ContactInfoDto> EditContactAsync(int id, UpdateContactDto updateContactDto);
    }
}
