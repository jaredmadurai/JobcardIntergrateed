using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobcardInter.Models;

namespace JobcardInter.Controllers
{
    public class InstallationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Installations
        public ActionResult Index()
        {
            return View(db.Installations.ToList());
        }

        // GET: Installations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Installation installation = db.Installations.Find(id);
            if (installation == null)
            {
                return HttpNotFound();
            }
            return View(installation);
        }

        // GET: Installations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Installations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,ClientName,BranchName,BranchNo,Address,Store_Manager,Tel,Fax,Email,Type,Antennas,Serial,Mental_Detector,Remote,Enterance1,Distance1,Enterance2,Distance2,Enterance3,Distance3,Enterance4,Distance4,Q1,Make,Lockable,Q2,Strength,TQ1,TType1,TQ2,TType2,TQ3,TType3,TQ4,TType4,Cable,Grouting,PPU,PPA,Power_Points,DB_Labelled,Comments1,Completion,SinedC,SignedD,Screen_Shots,Staff_Training_Conduct,Comment2,Name,Signature,Place,Date")] Installation installation)
        {

            DateTime datecreated2 = DateTime.Now;

            if (ModelState.IsValid)
            {
                installation.Date = datecreated2;
                db.Installations.Add(installation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(installation);
        }

        // GET: Installations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Installation installation = db.Installations.Find(id);
            if (installation == null)
            {
                return HttpNotFound();
            }
            return View(installation);
        }

        // POST: Installations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,ClientName,BranchName,BranchNo,Address,Store_Manager,Tel,Fax,Email,Type,Antennas,Serial,Mental_Detector,Remote,Enterance1,Distance1,Enterance2,Distance2,Enterance3,Distance3,Enterance4,Distance4,Q1,Make,Lockable,Q2,Strength,TQ1,TType1,TQ2,TType2,TQ3,TType3,TQ4,TType4,Cable,Grouting,PPU,PPA,Power_Points,DB_Labelled,Comments1,Completion,SinedC,SignedD,Screen_Shots,Staff_Training_Conduct,Comment2,Name,Signature,Place,Date")] Installation installation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(installation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(installation);
        }

        // GET: Installations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Installation installation = db.Installations.Find(id);
            if (installation == null)
            {
                return HttpNotFound();
            }
            return View(installation);
        }

        // POST: Installations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Installation installation = db.Installations.Find(id);
            db.Installations.Remove(installation);
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
