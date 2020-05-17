using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _LeahyHealthProject.Models;

namespace _LeahyHealthProject.Controllers
{
    [Authorize]
    public class calendersController : Controller
    {
        private DBleahyhealthEntities1 db = new DBleahyhealthEntities1();

        // GET: calenders
        public ActionResult Index()
        {
            return View(db.calenders.ToList());
        }

        // GET: calenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calender calender = db.calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        // GET: calenders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: calenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,Date,Time,Description")] calender calender)
        {
            if (ModelState.IsValid)
            {
                db.calenders.Add(calender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calender);
        }

        // GET: calenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calender calender = db.calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        // POST: calenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,Date,Time,Description")] calender calender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calender);
        }

        // GET: calenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calender calender = db.calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        // POST: calenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            calender calender = db.calenders.Find(id);
            db.calenders.Remove(calender);
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
