using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvisorSideKickMVC.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public int StudentId { get; set; }
        public string DepartmentName { get; set; }
        public string SchoolName { get; set; }

        public virtual ICollection<Advisor> Advisors { get; set; }

        public Department()
        {
            Advisors = new List<Advisor>();
        }

        public Department(string deptName, string school)
        {
            DepartmentName = deptName;
            SchoolName = school;
        }

        public Department(int dptId, int stdId, string deptName, string schoolName)
        {
            DepartmentId = dptId;
            StudentId = stdId;
            DepartmentName = deptName;
            SchoolName = schoolName;
        }
    }
}