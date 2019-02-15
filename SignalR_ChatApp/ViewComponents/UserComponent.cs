using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SignalR_ChatApp.Models;

namespace SignalR_ChatApp.ViewComponents
{
    public class UserComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int i)
        {
            // Show User table
            if(i == 0)
            {
                Database db = new Database();
                List<User> userList = db.RetrieveUsers();
                return View(userList);
            }
            // SaveUser result
            else if (i == 1)
            {
                return Content("TEST!");
            }
            else
            {
                return View();
            }
        }

        public IViewComponentResult SaveUser(string name)
        {
            Database db = new Database();
            SqlResult result = db.AddUser(new User { Name = name, MsgCount = 0 });
            return Content(result.Status);
        }

        public IViewComponentResult Test()
        {
            return Content("test");
        }
    }
}
