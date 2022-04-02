using ContactService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService service)
        {
            _contactService = service;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _contactService.GetAll();
            return Ok(contacts);
        }
    }
}
