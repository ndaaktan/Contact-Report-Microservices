using ContactService.Dtos;
using ContactService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }
        [HttpPost]
        public IActionResult AddContactInfo([FromBody] AddContactInformationDto _dto)
        {
            _contactInformationService.AddContactInformationByContactId(_dto);
            return Ok(_dto);
        }
        [HttpDelete]
        public IActionResult DeleteContactInfo(Guid id)
        {
            _contactInformationService.DeleteContactInformationByContactId(id);
            return Ok(id);
        }
        [HttpPut]
        public IActionResult UpdateContactInfo([FromBody] ContactInformationDto _dto)
        {
            _contactInformationService.UpdateContactInformation(_dto);
            return Ok(_dto);
        }
        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<ContactInformationDto>> GetAllContactInformation()
        {
            var contactInformations = _contactInformationService.GetAllInformation();
            return Ok(contactInformations);
        }
        [Route("GetInformationByContactId")]
        [HttpGet]
        public ActionResult<IEnumerable<ContactInformationDto>> GetAllContactInformationByContactId(Guid id)
        {
            var contactInformations = _contactInformationService.GetContactInformationByContactId(id);
            return Ok(contactInformations);
        }
        [Route("GetInformation")]
        [HttpGet]
        public IActionResult GetInformation(Guid id)
        {
            var contactInformations = _contactInformationService.GetInformation(id);
            return Ok(contactInformations);
        }
    }
}