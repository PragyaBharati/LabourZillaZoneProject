using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabourZillaZone12.Data;
using LabourZillaZone12.Models;

namespace LabourZillaZone12.Controllers
{
    public class laboursController : Controller
    {
        private LabourZillaZoneDbContext db = new LabourZillaZoneDbContext();

        // GET: labours
        public ActionResult Index()
        {
            return View(db.labours.ToList());
        }

        // GET: labours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            labour labour = db.labours.Find(id);
            if (labour == null)
            {
                return HttpNotFound();
            }
            return View(labour);
        }

        // GET: labours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: labours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Profession,CityAddress,StateL,DailyWages,TimeDate,Available,LContact,PasswordC,Confirm_password,LPic")] labour labour)
        {
            if (ModelState.IsValid)
            {
                db.labours.Add(labour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labour);
        }

        // GET: labours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            labour labour = db.labours.Find(id);
            if (labour == null)
            {
                return HttpNotFound();
            }
            return View(labour);
        }

        // POST: labours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Profession,CityAddress,StateL,DailyWages,TimeDate,Available,LContact,PasswordC,Confirm_password,LPic")] labour labour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labour);
        }

        // GET: labours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            labour labour = db.labours.Find(id);
            if (labour == null)
            {
                return HttpNotFound();
            }
            return View(labour);
        }

        // POST: labours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            labour labour = db.labours.Find(id);
            db.labours.Remove(labour);
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
