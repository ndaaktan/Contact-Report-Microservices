using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

        public ReportBackgroundService(IConfiguration configuration)
        {
            _configuration = configuration;
            Init();

        }
        private void Init()
        {

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
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
                switch (notification)
                {
                    case "ReportCreating":
                        //CreateReport
                        break;
                    default:
                        break;
                        {

                        }
                }

            };
            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
