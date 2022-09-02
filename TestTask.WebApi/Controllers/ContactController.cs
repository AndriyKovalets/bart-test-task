using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<ActionResult<ContactInfoDto>> AddContactAsync([FromBody] AddContactDto addContactDto)
        {
            var contact = await _contactService.AddContactAsync(addContactDto);

            return Created($"api/contact/{contact.Id}", contact);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactInfoDto>>> GetAllContactcAsync()
        {
            var contactList = await _contactService.GetAllContactsAsync();

            return Ok(contactList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfoDto>> GetContactAsync([FromRoute] int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactInfoDto>> GetContactAsync(
            [FromRoute] int id,
            [FromBody] UpdateContactDto updateContactDto)
        {
            var contact = await _contactService.EditContactAsync(id, updateContactDto);

            return Ok(contact);
        }
    }
}
