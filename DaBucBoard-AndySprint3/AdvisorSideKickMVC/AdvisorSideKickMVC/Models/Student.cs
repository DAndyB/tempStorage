using AdvisorSideKickMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FindMyAdvisorMVC.Models
{
public class Student
{
    [Key]
    public int AccountId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string HighSchool { get; set; }
    public virtual ICollection<Department> Departments { get; set; }

    public Student()
    {
        Departments = new List<Department>();
    }
}
}
