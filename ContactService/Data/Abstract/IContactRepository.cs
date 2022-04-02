using ContactService.Dtos;
using ContactService.Entities;
using System;
using System.Collections.Generic;

namespace ContactService.Data.Abstract
{
    public interface IContactRepository: IRepository<Contact>
    {
        //List<ContactInformationDto>  GetContactInfo(Guid id);
    }
}
