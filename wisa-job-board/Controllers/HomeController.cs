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

        public ActionResult Index(string location, string department)
        {
            var LocationList = new List<string>();
            var LocationQuery = from d in db.Jobs
                                orderby d.Location
                                select d.Location;
            LocationList.AddRange(LocationQuery.Distinct());
            SelectList locationSelect = new SelectList(LocationList);
            ViewBag.location = locationSelect;

            var DepartmentList = new List<string>();
            var DepartmentQuery = from d in db.Jobs
                                orderby d.Department
                                select d.Department;
            DepartmentList.AddRange(DepartmentQuery.Distinct());
            SelectList departmentSelect = new SelectList(DepartmentList);
            ViewBag.department = departmentSelect;

            var jobs = from j in db.Jobs
                       select j;


            if (!String.IsNullOrEmpty(location))
            {
                jobs = jobs.Where(x => x.Location == location);
            }

            if (!String.IsNullOrEmpty(department))
            {
                jobs = jobs.Where(x => x.Department == department);
            }

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