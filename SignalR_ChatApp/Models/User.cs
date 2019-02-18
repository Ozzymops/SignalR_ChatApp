using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ChatApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MsgCount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string LastLogin { get; set; }
        public int Attempts { get; set; }
    }
}
