using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WisaJobBoard.Models
{
    public class Application
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public string ResumePath { get; set; }

        public DateTime DateApplied { get; set; }

        public Job Job { get; set; }
    }
}