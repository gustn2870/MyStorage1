using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFacInfo.Context;
using WebFacInfo.Models;

namespace WebFacInfo.Controllers
{
    public class HomeController : Controller
    {
        private fDatabase db = new fDatabase();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.facilities.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fInfo fInfo = db.facilities.Find(id);
            if (fInfo == null)
            {
                return HttpNotFound();
            }
            return View(fInfo);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fID,fName,fDesc,fModel,fPrice")] fInfo fInfo)
        {
            if (ModelState.IsValid)
            {
                db.facilities.Add(fInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fInfo);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fInfo fInfo = db.facilities.Find(id);
            if (fInfo == null)
            {
                return HttpNotFound();
            }
            return View(fInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fID,fName,fDesc,fModel,fPrice")] fInfo fInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fInfo);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fInfo fInfo = db.facilities.Find(id);
            if (fInfo == null)
            {
                return HttpNotFound();
            }
            return View(fInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fInfo fInfo = db.facilities.Find(id);
            db.facilities.Remove(fInfo);
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
