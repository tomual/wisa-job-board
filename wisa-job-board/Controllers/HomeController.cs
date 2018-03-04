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

        public ActionResult Index(string location)
        {
            var LocationList = new List<string>();
            var LocationQuery = from d in db.Jobs
                                orderby d.Location
                                select d.Location;
            LocationList.AddRange(LocationQuery.Distinct());
            SelectList locationSelect = new SelectList(LocationList);
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "Select One" };
            ViewBag.locations = locationSelect;

            var jobs = from j in db.Jobs
                       select j;

            ViewBag.Jobs = jobs;

            if (!String.IsNullOrEmpty(location))
            {
                jobs = jobs.Where(x => x.Location == location);
            }

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