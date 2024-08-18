using System;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
	public class MessageHub : Hub
	{
		public MessageHub()
		{
		}

        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groups)
        {

            #region Caller
            // Sadece server a bildirim gonderen client la iletisim kurar
            // await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            // Server a bagli olan tum clientlarla iletisim kurar
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            // Sadece server a bildirim gonderen client disinda server a bagli olan
            // tum client lara mesaj gonderir
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Metotlari

            #region AllExcept
            // Belirtilen client lar haric server a bagli olan tum client lara bildiride bulunur
            // await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            // Server a bagli olan clientlar arasindan sadece belirli bir clienta bildiride bulunur
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            // Server a bagli olan clientlar arasindan sadece belirtilenlere bildiride bulunur
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            // Belirtilen gruptaki tum clientlara bildiride bulunur
            // Once gruplar olusturulmali ve ardindan clientlar gruplara subscribe olmali
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region GroupExcept
            // Belirtilen gruptaki, belirtilen clientlar disindaki tum clientlara mesaj iletmemizi saglayan fonksiyon
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Groups
            // Birden cok gruptaki clientlara bildiride bulunmamizi saglayan fonksiyondur
            //await Clients.Groups(groups).SendAsync("receiveMessage", message);
            #endregion
            #region OthersInGroup
            // Bildiride bulunan client haricinde gruptaki tum clientlara bildiride bulunan fonksiyondur
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region User

            #endregion
            #region Users

            #endregion
            #endregion

        }


        // hub a bir client baglandigi vakit tetiklenen event
        public override async Task OnConnectedAsync()
        {
			await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}

