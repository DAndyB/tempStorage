using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvisorSideKickMVC.Models
{
    public class Advisor
    {
        [Key]
        public int AdvisorId { get; set; }
        public int DepartmentId { get; set; }
        public string OfficeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdvisorEmail { get; set; }

        public Advisor()
        {
        }

        public Advisor(int adId, int deptId, string first, string last, string phone, string email)
        {
            AdvisorId = adId;
            DepartmentId = deptId;
            OfficeNumber = phone;
            FirstName = first;
            LastName = last;
            AdvisorEmail = email;
        }
    }
}