using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.Core.Inrerfaces.Services
{
    public interface IContactService
        : IBaseService<AddContactDto, ContactInfoDto, UpdateContactDto, int>
    {
    }
}
