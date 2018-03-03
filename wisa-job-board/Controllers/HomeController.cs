using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WisaJobBoard.Models;

namespace WisaJobBoard.Controllers
{
    public class HomeController : Controller
    {
        private JobDBContext db = new JobDBContext();

        public ActionResult Index()
        {
            var jobs = from j in db.Jobs
                       select j;

            ViewBag.Jobs = jobs;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}