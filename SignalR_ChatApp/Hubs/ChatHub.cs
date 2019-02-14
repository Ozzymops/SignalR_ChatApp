using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

using SignalR_ChatApp.Models;

namespace SignalR_ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        // chat.js
        public async Task SendMessage(string user, string message, int room)
        {
            // Zorg ervoor dat alle Clients binnen de room het nieuwe bericht binnen krijgen.
            await Clients.All.SendAsync("ReceiveMessage", user, message, room);
        }

        public async Task JoinMessage(string user, int room)
        {
            // Toon een bericht dat iemand de room is binnengekomen.
            await Clients.All.SendAsync("RoomMessage", user, room);
        }

        public async Task LeaveMessage(string user, int room)
        {
            // Toon een bericht dat iemand de room heeft verlaten.
            await Clients.All.SendAsync("LeaveMessage", user, room);
        }

        // csChat.js
        public async Task SendMessageCs(User user, Message msg, Room room)
        {
            await Clients.All.SendAsync("ReceiveMessage", user.Name, msg.Msg, room.Number);
        }
    }
}
