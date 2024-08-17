﻿using System;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
	public class MyHub : Hub
	{
		public async Task SendMessageAsync(string message)
		{
			await Clients.All.SendAsync("receiveMessage", message);
			Console.WriteLine(message);
		}
	}
}

