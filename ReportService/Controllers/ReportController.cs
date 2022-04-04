using ContactService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using ReportService.AsyncReportService;
using ReportService.Dtos;
using ReportService.Model;
using ReportService.Services.Abstract;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ReportService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IMessageProducer _messagePublisher;
        public ReportController(IReportService reportService, IMessageProducer messagePublisher)
        {
            _reportService = reportService;
            _messagePublisher = messagePublisher; 
        }
        [Route("GetAllReports")]
        [HttpGet]
        public IActionResult GetReports()
        {
            var result = _reportService.GetReports();
            return Ok(result);
        }

        [Route("CreateReport")]
        [HttpPost]
        public async Task<ActionResult<ReportResponse<Guid>>> CreateReport(ReportRequestDto reportRequestDto)
        {

            try
            {
                var reportId= await _reportService.Add(reportRequestDto);
                _messagePublisher.SendMessage(new GenerateReport{ 
                    ReportId=reportId,
                    Status="ReportCreating"
                });
                return Ok(
                     "Report request sent " + reportId.ToString()
                );
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [Route("DownloadReport")]
        [HttpGet]
        public async Task<ActionResult> DownloadReport(Guid uuid)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Reports");
            string filename = $@"{uuid}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(filePath, filename));
            if (file.Exists)
            {
                file = new FileInfo(Path.Combine(filePath, filename));
                FileStream fileStream = new FileStream(file.FullName, FileMode.Open);
                fileStream.Position = 0;
                var contentType = "application/octet-stream";
                return File(fileStream, contentType, filename);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
