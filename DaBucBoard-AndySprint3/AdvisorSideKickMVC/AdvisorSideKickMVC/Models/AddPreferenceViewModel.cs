using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvisorSideKickMVC.Models
{
    public class AddPreferenceViewModel
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string SchoolName { get; set; }
    }
}