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
    public class AdvisorListController : Controller
    {
        AdvisorSidekickDb _db = new AdvisorSidekickDb();

        /// <summary>
        /// Creates ActionResult for AdvisorList
        /// </summary>
        /// <returns>View model</returns>
        [Authorize]
        public ActionResult Index()
        {
            //Local Variables
            List<AdvisorListViewModel> AdvisorListMod = new List<AdvisorListViewModel>();
            Student student = _db.Students.FirstOrDefault(st => st.Email == User.Identity.Name);
            List<Advisor> advisors = _db.Advisors.ToList();

            //Get every advisor for each department
            if (student != null)
            {
                foreach (var department in student.Departments)
                {
                    foreach (var adv in advisors)
                    {
                        if (adv.DepartmentId == department.DepartmentId)
                        {
                            //Create view models
                            AdvisorListViewModel tempAdvMod = new AdvisorListViewModel(department, adv);
                            AdvisorListMod.Add(tempAdvMod);
                        }
                    } 
                }
            }
            return View("AdvisorListView", AdvisorListMod);
        }

        public ActionResult AddAdvisor()
        {
            var model = _db.Advisors
                .Select(a => new AddAdvisorViewModel
                {
                    AdvisorId = a.AdvisorId,
                    OfficeNumber = a.OfficeNumber,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    AdvisorEmail = a.AdvisorEmail
                });
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAdvisorPreference(int DepartmentId, int AdvisorId)
        {
            var user = User.Identity.GetUserName();
            var student = _db.Students.Single(s => s.Email == user);
            var department = _db.Departments.Find(DepartmentId);
            var advisor = _db.Advisors.Find(AdvisorId);

            if (ModelState.IsValid)
            {
                department.Advisors.Add(advisor);
                _db.Entry(department).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Email()
        {
            var model = new EmailModel();
            return View(model);
        }

        public ActionResult SendEmail(EmailModel model)
        {
            Student student = _db.Students.FirstOrDefault(st => st.Email == User.Identity.Name);
            System.Net.Mail.SmtpClient server = new System.Net.Mail.SmtpClient();
            string address = model.Address;
            string subject = model.Subject;
            string msg = model.Message;
            if (student != null)
            {
                //server.Send(student.Email, address, subject, msg);
            }
            return RedirectToAction("Index");
        }
    }
}