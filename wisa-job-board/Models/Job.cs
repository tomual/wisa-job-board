﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WisaJobBoard.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
    }

    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}