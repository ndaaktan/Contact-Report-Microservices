using ContactService.Dtos;
using ContactService.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactService.Services.Abstract
{
    public interface IContactInformationService
    {
        IEnumerable<ContactInformation> GetContactInformationByContactId(Guid Uuid);
        void DeleteContactInformationByContactId(Guid Uuid);
        void AddContactInformationByContactId(AddContactInformationDto _dto);
        void UpdateContactInformation(ContactInformationDto _dto);
        IEnumerable<GetContactInformation> GetAllInformation();
        GetContactInformation GetInformation(Guid Uuid);

    }
}
