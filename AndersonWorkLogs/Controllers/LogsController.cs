using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndersonWorkLogs.Controllers
{
    public class LogsController : Controller
    {
        // GET: Logs
        public ActionResult Logs()
        {
            return View();
        }
    }
}