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
    public class AirportTimeTablesController : Controller
    {
        private NewDB db = new NewDB();

        // GET: AirportTimeTables
        public ActionResult Index()
        {
            return View(db.AirportTimeTables.ToList());
        }

        // GET: AirportTimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            if (airportTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(airportTimeTable);
        }

        // GET: AirportTimeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirportTimeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AirlineID,CodeID,CityID,TermID,StatusID")] AirportTimeTable airportTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.AirportTimeTables.Add(airportTimeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airportTimeTable);
        }

        // GET: AirportTimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            if (airportTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(airportTimeTable);
        }

        // POST: AirportTimeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AirlineID,CodeID,CityID,TermID,StatusID")] AirportTimeTable airportTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airportTimeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airportTimeTable);
        }

        // GET: AirportTimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            if (airportTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(airportTimeTable);
        }

        // POST: AirportTimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            db.AirportTimeTables.Remove(airportTimeTable);
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
