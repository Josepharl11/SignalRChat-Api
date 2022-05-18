using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

namespace SignalRChat.Controllers
{

        [ApiController]
        [Route("[controller]")]
    public class ChatController : ControllerBase
        {
            private readonly IHubContext<ChatHub> hubContext;

            public ChatController(IHubContext<ChatHub> hubContext)
            {
                this.hubContext = hubContext;
            }

            [Route("chatHub")]
            [HttpPost]
            public IActionResult SendMessage([FromBody] ChatMessage messages)
            {
                hubContext.Clients.All.SendAsync("ReceiveOne", messages.userName, messages.msg);
                return Ok();
            }
        }
    }

