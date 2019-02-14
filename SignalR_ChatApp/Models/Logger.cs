using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ChatApp.Models
{
    public class Logger
    {
        public void Write(string msg)
        {
            int msgSize = msg.Count();
            Debug.WriteLine("[" + new string('!', msgSize+8) + "]");
            Debug.WriteLine("[LOGGER: " + msg + "]");
            Debug.WriteLine("[" + new string('!', msgSize + 8) + "]");
        }

        public void Write(Exception e)
        {
            Debug.WriteLine("[" + new string('!', 16) + "]");
            Debug.WriteLine("[LOGGER EXCEPTION: " + e.ToString() + "]");
            Debug.WriteLine("[" + new string('!', 16) + "]");
        }
    }
}
