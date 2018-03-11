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

        public string OwnerID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Date Posted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }
        
    }

    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        
        public System.Data.Entity.DbSet<WisaJobBoard.Models.Application> Application { get; set; }
    }
}