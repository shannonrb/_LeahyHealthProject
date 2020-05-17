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
    public class userdetailsController : Controller
    {
        private DBleahyhealthEntities db = new DBleahyhealthEntities();

        // GET: userdetails
        public ActionResult Index()
        {
            return View(db.userdetails.ToList());
        }

        // GET: userdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userdetail userdetail = db.userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // GET: userdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,date,time,bloodlevel")] userdetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.userdetails.Add(userdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdetail);
        }

        // GET: userdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userdetail userdetail = db.userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // POST: userdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,date,time,bloodlevel")] userdetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdetail);
        }

        // GET: userdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userdetail userdetail = db.userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // POST: userdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userdetail userdetail = db.userdetails.Find(id);
            db.userdetails.Remove(userdetail);
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
