using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ChatApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public int User { get; set; }
        public string Msg { get; set; }
    }
}
