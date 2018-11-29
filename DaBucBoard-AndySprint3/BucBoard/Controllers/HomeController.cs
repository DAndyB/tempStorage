using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BucBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "BucBoard Product Description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Developers of BucBoard";

            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Message = "This is the dashboard - Please enjoy";

            return View();
        }
        public ActionResult Appointment()
        {
            ViewBag.Message = "Schedule Bucpointment";

            return View();
        }
        public ActionResult Email()
        {
            ViewBag.Message = "Send Buc-mail";

            return View();
        }

    }
}