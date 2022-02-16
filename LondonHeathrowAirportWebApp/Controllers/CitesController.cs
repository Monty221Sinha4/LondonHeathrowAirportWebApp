using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LondonHeathrowAirportWebApp;

namespace LondonHeathrowAirportWebApp.Controllers
{
    public class CitesController : Controller
    {
        private NewDB db = new NewDB();

        // GET: Cites
        public ActionResult Index()
        {
            return View(db.Cites.ToList());
        }

        // GET: Cites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cites cites = db.Cites.Find(id);
            if (cites == null)
            {
                return HttpNotFound();
            }
            return View(cites);
        }

        // GET: Cites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityID,City")] Cites cites)
        {
            if (ModelState.IsValid)
            {
                db.Cites.Add(cites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cites);
        }

        // GET: Cites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cites cites = db.Cites.Find(id);
            if (cites == null)
            {
                return HttpNotFound();
            }
            return View(cites);
        }

        // POST: Cites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityID,City")] Cites cites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cites);
        }

        // GET: Cites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cites cites = db.Cites.Find(id);
            if (cites == null)
            {
                return HttpNotFound();
            }
            return View(cites);
        }

        // POST: Cites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cites cites = db.Cites.Find(id);
            db.Cites.Remove(cites);
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
