using ContactService.Dtos;
using ContactService.Entities;
using ContactService.Extensions;
using ContactService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IContactInformationService _contactInformationService;

        public ContactController(IContactService service, IContactInformationService contactInformationService)
        {
            _contactService = service;
            _contactInformationService = contactInformationService;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _contactService.GetAll();
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult AddContact([FromBody] ContactDto _dto)
        {
            var contact = _contactService.AddContact(_dto).ConvertToEntity();




            //return CreatedAtRoute(nameof(GetContactById), new { Id = contact.Uuid }, _dto);

            return Ok(contact);
        }
        [HttpPut]
        public IActionResult UpdateContact([FromBody] ContactDto _dto)
        {
            _contactService.UpdateContact(_dto);
            return Ok(_dto);
        }
        [HttpGet("{id}", Name = "GetContactById")]
        public IActionResult GetContactById(Guid id)
        {
            return Ok(_contactService.GetContact(id));
        }
        [HttpDelete]
        public IActionResult DeleteContact(Guid id)
        {
            _contactInformationService.DeleteContactInformationByContactId(id);
            _contactService.DeleteContact(id);
            return Ok(id);
        }
        [Route("GetcontactWithInfo")]
        [HttpGet]
        public IActionResult GetcontactWithInfo(Guid id)
        {
            var result= _contactService.GetContactInformation(id);
            return Ok(result);
        }

    }
}
