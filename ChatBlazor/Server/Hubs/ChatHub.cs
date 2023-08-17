using Microsoft.AspNetCore.SignalR;

namespace ChatBlazor.Server.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);//sent message 
		}
    }
}
