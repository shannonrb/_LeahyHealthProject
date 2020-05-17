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
    public class userdetails2Controller : Controller
    {
        private DBleahyhealthEntities db = new DBleahyhealthEntities();

        // GET: userdetails2
        public ActionResult Index()
        {
            return View(db.userdetails2.ToList());
        }

        // GET: userdetails2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userdetails2 userdetails2 = db.userdetails2.Find(id);
            if (userdetails2 == null)
            {
                return HttpNotFound();
            }
            return View(userdetails2);
        }

        // GET: userdetails2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userdetails2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,date,starttime,endtime,exercise")] userdetails2 userdetails2)
        {
            if (ModelState.IsValid)
            {
                db.userdetails2.Add(userdetails2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdetails2);
        }

        // GET: userdetails2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userdetails2 userdetails2 = db.userdetails2.Find(id);
            if (userdetails2 == null)
            {
                return HttpNotFound();
            }
            return View(userdetails2);
        }

        // POST: userdetails2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,date,starttime,endtime,exercise")] userdetails2 userdetails2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userdetails2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdetails2);
        }

        // GET: userdetails2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userdetails2 userdetails2 = db.userdetails2.Find(id);
            if (userdetails2 == null)
            {
                return HttpNotFound();
            }
            return View(userdetails2);
        }

        // POST: userdetails2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userdetails2 userdetails2 = db.userdetails2.Find(id);
            db.userdetails2.Remove(userdetails2);
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
