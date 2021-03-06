using ContactService.Data.Abstract;
using ContactService.Dtos;
using ContactService.Services.Abstract;
using System;
using System.Collections.Generic;
using ContactService.Extensions;
using System.Linq;
using ContactService.Entities;

namespace ContactService.Services.Concrete
{
    public class ContactServices : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactServices(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

        }
        public ContactDto AddContact(ContactDto _dto)
        {
            var _v = _dto.ConvertToEntity();
            return _contactRepository.Add(_v).ConvertToDto();
        }

        public void DeleteContact(Guid id)
        {
            _contactRepository.Delete(id);
        }

        public IQueryable<ContactDto> GetAll()
        {
            return _contactRepository.GetAll().Select(x => x.ConvertToDto());
        }

        public ContactDto GetContact(Guid id)
        {
            return _contactRepository.Get(x => x.Uuid == id).ConvertToDto();
        }

        public List<ContactInformation> GetContactInformation(Guid id)
        {
            var contacts = _contactRepository.GetContactWithcontactInformation(id);

            return contacts;
        }

        public void UpdateContact(ContactDto _dto)
        {
            _contactRepository.Update(_dto.ConvertToEntity());
        }

        List<ContactInformation> IContactService.GetContactInformation(Guid id)
        {
            return _contactRepository.GetContactWithcontactInformation(id).ToList();
        }
    }
}
