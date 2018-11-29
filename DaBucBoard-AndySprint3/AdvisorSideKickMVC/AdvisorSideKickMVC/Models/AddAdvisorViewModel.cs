using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvisorSideKickMVC.Models
{
    public class AddAdvisorViewModel
    {
        public int AdvisorId { get; set; }
        public string OfficeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdvisorEmail { get; set; }
    }
}