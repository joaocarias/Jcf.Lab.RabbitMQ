using Jcf.Lab.RabbitMQ.Api.Models;

namespace Jcf.Lab.RabbitMQ.Api.MessagingBroker.IMessagesBrokers
{
    public interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string queueName);
    }
}
