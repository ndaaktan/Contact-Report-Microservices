using ContactService.Model;
using System.Threading.Tasks;
using ContactService.Dtos;

namespace ContactService.Http.Abstract
{
    public interface IReportClient
    {
        Task<ReportResponse<string>> SendReportRequest(ReportRequest request);

    }
}
