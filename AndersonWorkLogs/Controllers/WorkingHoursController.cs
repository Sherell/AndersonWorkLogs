using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndersonWorkLogs.Controllers
{
    public class WorkingHoursController : Controller
    {
        // GET: WorkingHours
        public ActionResult Index()
        {
            return View();
        }
    }
}