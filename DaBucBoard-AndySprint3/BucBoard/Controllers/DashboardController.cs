using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BucBoard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            ViewBag.Message = "This is the dashboard";
            return View();
        }
    }
}