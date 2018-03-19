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
        public ActionResult Index(int? jobId)
        {
            var applications = db.Application.Include(a => a.Job);

            if (jobId.HasValue)
            {
                applications = applications.Where(a => a.Job.ID == jobId);
            }

            return View(applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Include(a => a.Job).SingleOrDefault(a => a.ID == id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
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
        public ActionResult Create(int? id, [Bind(Include = "ID,FullName,Email,Phone,Message")] Application application)
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
            application.Job = job;
            if (Request.Files["file"].ContentLength == 0)
            {
                ModelState.AddModelError("ResumePath", "Please upload file");
            }
            else
            {
                string folder = Server.MapPath("~/Uploads/");
                string name = Path.GetFileName(Request.Files["file"].FileName);
                Console.WriteLine(name);
                string path = Path.Combine(folder, name);
                Request.Files["file"].SaveAs(path);
                application.ResumePath = path;
            }
            application.DateApplied = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Application.Add(application);
                db.SaveChanges();
                return RedirectToAction("Submitted");
            }

            ViewBag.Job = job;
            return View(application);
        }

        public ActionResult Submitted()
        {
            return View();
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Email,Phone,Message,DateApplied")] Application application)
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].ContentLength == 0) continue;
                string folder = Server.MapPath("~/Uploads/");
                string name = Path.GetFileName(Request.Files[upload].FileName);
                Console.WriteLine(name);
                string path = Path.Combine(folder, name);
                Request.Files[upload].SaveAs(path);
                application.ResumePath = path;
            }
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Application.Find(id);
            db.Application.Remove(application);
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

        // GET: Applications/Edit/5
        public ActionResult Download(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application applications = db.Application.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            FileInfo file = new FileInfo(applications.ResumePath);
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.Name));
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.TransmitFile(file.FullName);
            Response.End();
            return View(applications);
        }
    }
}
