using Microsoft.AspNetCore.Mvc;
using ReportService.Services.Abstract;

namespace ReportService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        public IActionResult GetReports()
        {
            var result = _reportService.GetReports();
            return Ok(result);
        }
    }
}
