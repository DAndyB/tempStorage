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
        public string DepartmentName { get; set; }
        public string SchoolName { get; set; }
        
        public virtual ICollection<Advisor> Advisors { get; set; }

        public Department()
        {
            Advisors = new List<Advisor>();
        }
    }
}