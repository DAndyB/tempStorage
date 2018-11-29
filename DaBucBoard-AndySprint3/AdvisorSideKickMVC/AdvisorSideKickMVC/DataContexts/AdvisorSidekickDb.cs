using AdvisorSideKickMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FindMyAdvisorMVC.Models
{
    public class AdvisorSidekickDb : DbContext
    {
        public AdvisorSidekickDb() : base("name=DefaultConnection")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Advisor> Advisors { get; set; }

    }
}