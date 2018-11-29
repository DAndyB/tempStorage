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
    public class ProfileController : Controller
    {
        /// <summary>
        /// Initialize the database context class
        /// </summary>
        AdvisorSidekickDb _db = new AdvisorSidekickDb();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
        // GET: Profile
        public ActionResult Index()
        {
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

        // GET: Profile/Details/5
        public ActionResult Advisors(int? departmentId)
        {
            if (departmentId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var DepartmentOfAdvisors = _db.Departments.Find(departmentId);
            if (DepartmentOfAdvisors == null)
            {
                return HttpNotFound("Sorry, but cannot find category with id: " + departmentId);
            }
            return View(DepartmentOfAdvisors);
        }


        // GET: Profile/Delete/5
        public ActionResult DeleteDepartment(int? DepartmentId)
        {
            if (DepartmentId == null)
            {
                return RedirectToAction("Index", "Profile");
            }
            var profileInfo = _db.Departments.Find(DepartmentId);
            if (profileInfo == null)
            {
                return HttpNotFound("Sorry, but could not find that department: " + DepartmentId);
            }
            return View(profileInfo);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("DeleteDepartment")]
        public ActionResult DeleteDepConfirmed(int? DepartmentId)
        {
            var email = User.Identity.GetUserName();
            Department department = _db.Departments.Find(DepartmentId);

            foreach (var source in _db.Departments.Where(fk => fk.DepartmentId == DepartmentId))
            {
                _db.Departments.Remove(source);
            }
            _db.SaveChanges();

            _db.Departments.Remove(department);
            _db.SaveChanges();
            return RedirectPermanent("/profile/index?email=" + User.Identity.GetUserName());

        }
        public ActionResult DeleteAdvisor(int? AdvisorId)
        {
            if (AdvisorId == null)
            {
                return RedirectToAction("Index", "Profile");
            }
            var advisor = _db.Advisors.Find(AdvisorId);
            if (advisor == null)
            {
                return HttpNotFound("Sorry, but could not find that advisor: " + AdvisorId);
            }
            return View(advisor);
        }
        [HttpPost, ActionName("DeleteAdvisor")]
        public ActionResult DeleteAdvisorConfirmed(int? sourceId)
        {

            Advisor advisor = _db.Advisors.Find(sourceId);

            _db.Advisors.Remove(advisor);
            _db.SaveChanges();
            return RedirectPermanent("/profile/index?email=" + User.Identity.GetUserName());
        }
    }
}
