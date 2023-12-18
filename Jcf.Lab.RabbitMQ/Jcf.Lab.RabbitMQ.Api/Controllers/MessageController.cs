using Jcf.Lab.RabbitMQ.Api.MessagingBroker.IMessagesBrokers;
using Jcf.Lab.RabbitMQ.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Jcf.Lab.RabbitMQ.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class MessageController : ControllerBase
    {
        public readonly IRabbitMQMessageSender _messageSender;

        public MessageController(IRabbitMQMessageSender messageSender)
        {
            _messageSender = messageSender
                ?? throw new ArgumentNullException(nameof(messageSender));
        }

        [HttpPost]
        public IActionResult SendMessage(SendMessageDTO model)
        {

            _messageSender.SendMessage(model, "queueTeste");

            return Ok(model);
        }

      
    }
}
