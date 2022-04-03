using ContactService.Dtos;
using ContactService.Entities;
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
        List<ContactInformation> GetContactInformation(Guid id);
        ContactDto AddContact(ContactDto _dto);
        void UpdateContact(ContactDto _dto);  


    }
}
