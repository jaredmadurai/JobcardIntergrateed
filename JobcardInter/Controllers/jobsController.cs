using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobcardInter.Models;
using Rotativa.MVC;
using System.IO;

namespace JobcardInter.Controllers
{
    public class jobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: jobs
        public ActionResult Index()
        {
            List<job> filemodelList = new List<job>();
            filemodelList = db.jobs.ToList();

            return View("Index", filemodelList);





            //return View(db.jobs.ToList());
        }

        public ActionResult GetAll()
        {
            var allproducts = db.jobs.ToList();
            return View(allproducts);
        }


        public ActionResult PrintAll()
        {
            var q = new ActionAsPdf("GetAll");
            return q;
        }







        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase file)
        //{


        //    return RedirectToAction("Index");
        //}

        //public ActionResult ViewUpload()
        //{
        //    return View("Upload");
        //}

        //public ActionResult UploadList()
        //{
        //    List<job> filemodelList = new List<job>();
        //    filemodelList = db.jobs.ToList();

        //    return View("UploadList", filemodelList);
        //}










        // GET: jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(job job, HttpPostedFileBase file)
        {

            DateTime datecreated2 = DateTime.Now;

            if (ModelState.IsValid)
            {
                job.DepartureA = datecreated2;
                job.SubTotal = job.CalcSubTotal();
                job.Vat = job.CalcVat();
                job.GrandTotal = job.CalcGrandTotal();
                db.jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(@"~/Content/data"), fileName);
                job fileModel = new job();
                fileModel.Name1 = fileName;
                db.jobs.Add(fileModel);
                db.SaveChanges();
                file.SaveAs(path);
            }
            return View(job);
        }

        // GET: jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,ClientReference,Date,Client,Email,ContactPerson,Telephone,SiteLocation,DoorType,Service,Callout,Installation,Supply,WCO,Reason,Comment,DateA,ArrivalA,DepartureA,TotalA,Travelling,Km,TotalD,QuanityA,TotalQA,QuanityB,TotalQB,QuanityC,TotalQC,QuanityD,TotalQE,SubTotal,Vat,GrandTotal,Technican,DateCompleted,Signature,Name,Designation,Dater,Time,SignatureB,Name1")] job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            job job = db.jobs.Find(id);
            db.jobs.Remove(job);
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