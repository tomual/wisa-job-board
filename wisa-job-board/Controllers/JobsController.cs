using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WisaJobBoard.Models;

namespace WisaJobBoard.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private JobDBContext db = new JobDBContext();

        // GET: Jobs
        [AllowAnonymous]
        public ActionResult Index(string search, string location, string department)
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

            if(!String.IsNullOrEmpty(search))
            {
                jobs = jobs.Where(s => s.Title.Contains(search));
            }

            if (!String.IsNullOrEmpty(department))
            {
                jobs = jobs.Where(x => x.Department == department);
            }

            if (!String.IsNullOrEmpty(location))
            {
                jobs = jobs.Where(x => x.Location == location);
            }

            return View(jobs);
        }

        // GET: Jobs/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Location,Description,Department")] Job job)
        {
            job.DatePosted = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Location,Description,DatePosted,Department")] Job job)
        {
            Console.WriteLine(job.DatePosted);
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            for (int i = 0; i < job.Applications.Count; i++)
            {
                var application = job.Applications.ToArray()[i];
                job.Applications.Remove(application);
            }
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
