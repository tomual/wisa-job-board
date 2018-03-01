using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WisaJobBoard.Models;

namespace WisaJobBoard
{
    [Authorize]
    public class ApplicationsController : Controller
    {
        private JobDBContext db = new JobDBContext();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            return View(applications);
        }

        // GET: Applications/Create
        [AllowAnonymous]
        public ActionResult Create(int? id)
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
            ViewBag.Job = job;
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,Phone,Location,Message,DateApplied")] Applications applications)
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].ContentLength == 0) continue;
                string folder = Server.MapPath("~/Uploads/");
                string name = Path.GetFileName(Request.Files[upload].FileName);
                Console.WriteLine(name);
                string path = Path.Combine(folder, name);
                Request.Files[upload].SaveAs(path);
                applications.ResumePath = path;
            }
            if (ModelState.IsValid)
            {
                db.Applications.Add(applications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applications);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            return View(applications);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,Phone,Location,Message,DateApplied")] Applications applications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applications);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            return View(applications);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applications applications = db.Applications.Find(id);
            db.Applications.Remove(applications);
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
