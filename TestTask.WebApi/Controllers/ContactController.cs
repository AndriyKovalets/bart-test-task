using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController
        : BaseController<AddContactDto, ContactInfoDto, UpdateContactDto, int, IContactService>
    {
        public ContactController(IContactService contactService) : base(contactService) { }
    }
}
