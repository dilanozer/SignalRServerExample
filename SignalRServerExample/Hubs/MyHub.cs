using System;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs
{
	public class MyHub : Hub<IMessageClient>
	{
        static List<string> clients = new List<string>();
        private static readonly object _lock = new object();

        //public async Task SendMessageAsync(string message)
		//{
		//	await Clients.All.SendAsync("receiveMessage", message);
		//}

        // sisteme baglanti gerceklestiginde tetiklenen
        public override async Task OnConnectedAsync()
        {
            lock (_lock)
            {
                clients.Add(Context.ConnectionId);
            }
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        // sistemde var olan bir baglanti koptugunda tetiklenen
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            lock (_lock)
            {
                clients.Remove(Context.ConnectionId);
            }
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }
    }
}

