using Jcf.Lab.RabbitMQ.Api.MessagingBroker.IMessagesBrokers;
using Jcf.Lab.RabbitMQ.Api.Models;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;

namespace Jcf.Lab.RabbitMQ.Api.MessagingBroker
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMQMessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void SendMessage(BaseMessage baseMessage, string queueName)
        {
            var factoty = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };

            _connection = factoty.CreateConnection();

            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            byte[] body = GetMessageAsByteArray(baseMessage);
            channel.BasicPublish(
                    exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize<SendMessageDTO>((SendMessageDTO)message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;

        }
    }
}
