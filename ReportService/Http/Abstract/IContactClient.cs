using ReportService.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.Http.Abstract
{
    public interface IContactClient
    {
        Task<IEnumerable<ContactInformation>> GetAllInformations();
    }
}
