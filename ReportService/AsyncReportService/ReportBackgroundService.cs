using ContactService.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OfficeOpenXml;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportService.Data.Abstract;
using ReportService.Dtos;
using ReportService.Http.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportService.AsyncReportService
{
    public class ReportBackgroundService : BackgroundService
    {
        private IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;
        private readonly IServiceScopeFactory _scopeFactory;

        public ReportBackgroundService(IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _configuration = configuration;
            Init();

        }
        private void Init()
        {

            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ"],
                UserName = _configuration["RabbitMQUser"],
                Password = _configuration["RabbitMQPass"],
                VirtualHost = "/",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(type: ExchangeType.Fanout, exchange: "trigger");
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "trigger", routingKey: "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ModuleHandle, ea) =>
            {
                var body = ea.Body;
                var notification = Encoding.UTF8.GetString(body.ToArray());
                var json = JsonConvert.DeserializeObject<GenerateReport>(notification);
                if (json.Status== "ReportCreating")
                {
                    CreateReport(notification);
                }
            };
            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
        public void CreateReport(string reportMessage)
        {
            List<ReportResultDto> resultList = new List<ReportResultDto>();
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IReportRepository>();
                var contactclient = scope.ServiceProvider.GetRequiredService<IContactClient>();
                var reportRequestDto = JsonConvert.DeserializeObject<GenerateReport>(reportMessage);
                try
                {
                    var reportObj = repo.Get(x => x.Uuid == reportRequestDto.ReportId);

                    var allInfos = contactclient.GetAllInformations().Result;

                    var locations = allInfos.GroupBy(x => new { x.ContactInformationType, x.Information })
                    .Where(x => x.Key.ContactInformationType == Entities.ContactInformationType.Location).Select(x => x.Key.Information);
                    foreach (var l in locations)
                    {
                        ReportResultDto locationResultDto = new ReportResultDto();
                        locationResultDto.Location = l;
                        locationResultDto.ContactCount = allInfos.Where(x => x.ContactInformationType == Entities.ContactInformationType.Location
                         && x.Information == l).GroupBy(x => x.ContactUuid).Count();
                        var locationContactIds = allInfos.Where(x => x.ContactInformationType == Entities.ContactInformationType.Location
                       && x.Information == l).GroupBy(x => x.ContactUuid).Select(x => x.Key).ToList();
                        resultList.Add(locationResultDto);
                        locationResultDto.ContactNumber = allInfos.Where(x => x.ContactInformationType == Entities.ContactInformationType.PhoneNumber && locationContactIds.Contains(x.ContactUuid)).Count();
                        resultList.Add(locationResultDto);
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Reports");
                    string fileName = $@"{reportRequestDto.ReportId}.xlsx";
                    FileInfo file = new FileInfo(Path.Combine(path, fileName));
                    if (file.Exists)
                    {
                        file.Delete();
                        file = new FileInfo(Path.Combine(path, fileName));
                    }
                    using (ExcelPackage pckg = new ExcelPackage(file))
                    {

                        ExcelWorksheet _excel = pckg.Workbook.Worksheets.Add("Report");
                        _excel.Cells[1, 1].Value = "Location Info";
                        _excel.Cells[1, 2].Value = "Contact Count";
                        _excel.Cells[1, 3].Value = "Contact Number";


                        for (int i = 0; i < resultList.Count; i++)
                        {
                            _excel.Cells[$"A{i + 2}"].Value = resultList[i].Location;
                            _excel.Cells[$"B{i + 2}"].Value = resultList[i].ContactCount;
                            _excel.Cells[$"C{i + 2}"].Value = resultList[i].ContactNumber;

                        }
                        pckg.Save();
                    }
                    reportObj.ReportStat = Entities.ReportStatusType.Completed;
                    repo.Update(reportObj).Wait();
                }
                catch (Exception ex)
                {
                }
            }
        }

    }
}
