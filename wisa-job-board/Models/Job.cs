using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WisaJobBoard.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Posted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }
    }

    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}