using Jcf.Lab.RabbitMQ.Api.Models;

namespace Jcf.Lab.RabbitMQ.Api.MessagingBroker.IMessagesBrokers
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
