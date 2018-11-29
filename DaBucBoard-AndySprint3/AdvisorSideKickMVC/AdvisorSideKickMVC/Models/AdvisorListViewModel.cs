using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvisorSideKickMVC.Models
{
    public class AdvisorListViewModel
    {
        public Department Dept { get; set; }
        public Advisor AdvisorListEntry { get; set; }

        public AdvisorListViewModel()
        {
        }

        public AdvisorListViewModel(Department dpt, Advisor adv)
        {
            Dept = dpt;
            AdvisorListEntry = adv;
        }

        
    }
}