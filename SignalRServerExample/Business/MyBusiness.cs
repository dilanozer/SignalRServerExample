﻿using System;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Hubs;

namespace SignalRServerExample.Business
{
	public class MyBusiness
	{
		readonly IHubContext<MyHub> _hubContext;

		public MyBusiness(IHubContext<MyHub> hubContext)
		{
			_hubContext = hubContext;
		}

        public async Task SendMessageAsync(string message)
        {
        	await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}

