using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisaJobBoard.Models
{
    public class Applications
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public string message { get; set; }
        public DateTime DateApplied { get; set; }
    }
}