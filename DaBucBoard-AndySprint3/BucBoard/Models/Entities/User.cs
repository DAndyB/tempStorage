using System;
using System.Collections.Generic;

namespace BucBoard.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Calendar = new HashSet<Calendar>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? OfficeNumber { get; set; }
        public string Department { get; set; }
        public byte? IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Calendar> Calendar { get; set; }
    }
}
