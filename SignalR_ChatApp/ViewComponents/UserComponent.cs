using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ChatApp.ViewComponents
{
    public class UserComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Models.Database db = new Models.Database();
            List<Models.User> userList = db.RetrieveUsers();
            return View(userList);
        }
    }
}
