using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisaJobBoard.Models
{
    public class Applications
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public string ResumePath { get; set; }
        public DateTime DateApplied { get; set; }
    }
}