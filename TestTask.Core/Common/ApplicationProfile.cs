using AutoMapper;
using TestTask.Domain.Dtos.AccountDtos;
using TestTask.Domain.Dtos.ContactDtos;
using TestTask.Domain.Entities;

namespace TestTask.Core.Common
{
    internal class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<AddContactDto, Contact>();
            CreateMap<Contact, ContactInfoDto>();
            CreateMap<UpdateContactDto, Contact>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AddAccountDto, Account>();
            CreateMap<Account, AccountInfoDto>();
            CreateMap<UpdateAccountDto, Account>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
