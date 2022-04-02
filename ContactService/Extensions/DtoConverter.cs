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
    }
}
