using ContactService.Data.Abstract;
using ContactService.Dtos;
using ContactService.Entities;
using ContactService.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactService.Extensions;


namespace ContactService.Services.Concrete
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IContactRepository _contactRepository;

        public ContactInformationService(IContactInformationRepository contactInformationRepository, IContactRepository contactRepository)
        {
            _contactInformationRepository = contactInformationRepository;
            _contactRepository = contactRepository;


        }

        public void AddContactInformationByContactId(AddContactInformationDto _dto)
        {
            _contactInformationRepository.Add(_dto.ConvertToEntity());
        }

        public void DeleteContactInformationByContactId(Guid Uuid)
        {
            _contactInformationRepository.Delete(Uuid);
        }

        public IEnumerable<GetContactInformation> GetAllInformation()
        {
            var _contacts = _contactInformationRepository.GetAll().Select(x => x.ConvertToDto());
            return _contacts;
        }

        public IEnumerable<ContactInformation> GetContactInformationByContactId(Guid Uuid)
        {
            return _contactInformationRepository.GetAll(x => x.ContactUuid == Uuid).ToList();
        }
        public void UpdateContactInformationByContactId(AddContactInformationDto _dto)
        {
            _contactInformationRepository.Update(_dto.ConvertToEntity());
        }

        public void UpdateContactInformation(ContactInformationDto _dto)
        {
            _contactInformationRepository.Update(_dto.ConvertToEntity());
        }

        public GetContactInformation GetInformation(Guid Uuid)
        {
            return _contactInformationRepository.Get(x => x.Uuid == Uuid).ConvertToDto();
        }
    }
}
