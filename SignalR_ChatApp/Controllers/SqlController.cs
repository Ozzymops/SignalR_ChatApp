using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SignalR_ChatApp.Controllers
{
    public class SqlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Sql/SaveUser")]
        public ActionResult SaveUser(string name)
        {
            Models.Database db = new Models.Database();
            return Content(db.AddUser(new Models.User { Name = name }).Status);
        }
    }
}