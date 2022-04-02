using ContactService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactService.Services.Abstract
{
    public interface IContactService
    {
        ContactDto GetContact(Guid id);
        IQueryable<ContactDto> GetAll();  
        void DeleteContact(Guid id);
        List<ContactInformationDto> GetContactInformation(Guid id);
        ContactDto AddContact(ContactDto _dto);
        void UpdateContact(ContactDto _dto);  

    }
}
