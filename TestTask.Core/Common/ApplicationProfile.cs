using AutoMapper;
using TestTask.Domain.Dtos.AccountDtos;
using TestTask.Domain.Dtos.ContactDtos;
using TestTask.Domain.Dtos.IncidentDtos;
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
            CreateMap<Contact, Contact>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AddIncidentFullInfoDto, Contact>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.ContactFirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.ContactLastName))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.ContactEmail));

            CreateMap<AddAccountDto, Account>();
            CreateMap<Account, AccountInfoDto>();
            CreateMap<Account, AccountFullInfoDto>();
            CreateMap<UpdateAccountDto, Account>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AddIncidentDto, Incident>();
            CreateMap<Incident, IncidentInfoDto>();
            CreateMap<Incident, IncidentFullInfoDto>();
            CreateMap<UpdateIncidentDto, Incident>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
