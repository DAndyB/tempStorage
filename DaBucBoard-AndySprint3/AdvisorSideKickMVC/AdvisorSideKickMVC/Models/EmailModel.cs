using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvisorSideKickMVC.Models
{
    public class EmailModel
    {
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public EmailModel()
        {

        }

        public EmailModel(string Addr, string Subj, string Msg)
        {
            Address = Addr;
            Subject = Subj;
            Message = Msg;
        }


    }
}