using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvisorSideKickMVC.Models
{
    public class PreferenceInfoViewModel
    {
        public PreferenceInfoViewModel() {
        }

        public PreferenceInfoViewModel(string schoolName, string departmentName, int advisorCount)
        {
            SchoolName = schoolName;
            DepartmentName = departmentName;
            AdvisorCount = advisorCount;
        }


        public string SchoolName { get; set; }
        public string DepartmentName { get; set; }
        public int AdvisorCount { get; set; }
    }
}