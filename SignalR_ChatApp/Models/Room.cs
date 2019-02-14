using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ChatApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<User> UserList { get; set; }
        public List<Message> MessageList { get; set; }
    }
}
