using ContactService.Dtos;
using ContactService.Entities;

namespace ContactService.Extensions
{
    public static class DtoConverter
    {
        public static Contact ConvertToEntity(this ContactDto _dto) =>
           new Contact
           {
               Name = _dto.Name,
               Surname = _dto.Surname,
               Uuid = _dto.Uuid,
               Company = _dto.Company,

           };

        public static ContactDto ConvertToDto(this Contact _entity) =>
            new ContactDto
            {
                Name = _entity.Name,
                Surname = _entity.Surname,
                Uuid = _entity.Uuid,
                Company = _entity.Company,

            };
        public static ContactInformation ConvertToEntity(this AddContactInformationDto _dto) =>
       new ContactInformation
       {
           ContactInformationType = _dto.ContactInformationType,
           ContactUuid = _dto.ContactUuid,
           Information = _dto.Information
       };
        public static GetContactInformation ConvertToDto(this ContactInformation _dto) =>
      new GetContactInformation
      {
          ContactInformationType = _dto.ContactInformationType,
          ContactUuid = _dto.ContactUuid,
          Information = _dto.Information,
          Uuid = _dto.Uuid,
          InformationType = _dto.ContactInformationType.ToString()
      };
        public static ContactInformation ConvertToEntity(this GetContactInformation _dto) =>
          new ContactInformation
          {
              ContactInformationType = _dto.ContactInformationType,
              ContactUuid = _dto.ContactUuid,
              Information = _dto.Information,
              Uuid = _dto.Uuid,
          };
        public static ContactInformation ConvertToEntity(this ContactInformationDto _dto) =>
         new ContactInformation
         {
             ContactInformationType = _dto.ContactInformationType,
             ContactUuid = _dto.ContactUuid,
             Information = _dto.Information,
             Uuid = _dto.Uuid,
         };
       
    }
}
