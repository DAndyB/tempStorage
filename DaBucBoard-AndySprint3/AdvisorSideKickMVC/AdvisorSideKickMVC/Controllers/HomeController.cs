using AdvisorSideKickMVC.Models;
using FindMyAdvisorMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AdvisorSideKickMVC.Controllers
{
    public class HomeController : Controller
    {
        AdvisorSidekickDb _db = new AdvisorSidekickDb();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

        [Authorize]
        public ActionResult Index()
        {
            List<PreferenceInfoViewModel> Preferences = new List<PreferenceInfoViewModel>();
            Student student = _db.Students.FirstOrDefault(st => st.Email == User.Identity.Name);


            if (student != null)
            {
                foreach (var department in student.Departments)
                {
                    PreferenceInfoViewModel preference = new PreferenceInfoViewModel(department.SchoolName, department.DepartmentName, department.Advisors.Count);

                    Preferences.Add(preference);
                } 
            }

            return View("PreferenceList", Preferences);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddDepartment()
        {
            var model = _db.Departments
                .Select(d => new AddPreferenceViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                    SchoolName = d.SchoolName
                });
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDepartment(int? DepartmentId)
        {
            var user = User.Identity.GetUserName();
            var student = _db.Students.Single(s => s.Email == user);
            var department = _db.Departments.Find(DepartmentId);

            if (ModelState.IsValid)
            {
                student.Departments.Add(department);
                _db.Entry(student).State = EntityState.Modified;
                _db.SaveChanges();
            }
            _db.Students.FirstOrDefault(st => st.Email == User.Identity.Name).Departments.Add(department);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}