using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace ReportService.AsyncReportService
{
    public class RabbitMqProducer : IMessageProducer
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqProducer(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ"],
                UserName = _configuration["RabbitMQUser"],
                Password = _configuration["RabbitMQPass"],
                VirtualHost = "/",
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: "trigger", routingKey: "reports", basicProperties: null, body: body);
        }
    }
}
