using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userName, string msg)
        {
            await Clients.All.SendAsync("ReceiveOne", userName, msg);
        }
    }
}
