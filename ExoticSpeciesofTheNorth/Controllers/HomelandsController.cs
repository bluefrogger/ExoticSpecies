/*
    Author: Alex Yoo
    Content: All possible homelands of species around the world. Scaffolded code unchanged.
    Usage: ~/Homelands
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExoticSpeciesOfTheNorth.Models;

namespace ExoticSpeciesOfTheNorth.Controllers
{
    public class HomelandsController : Controller
    {
        private ExoticSpeciesDbContext db = new ExoticSpeciesDbContext();

        // GET: Homelands
        public ActionResult Index()
        {
            return View(db.MyHomelands.ToList());
        }

        // GET: Homelands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homeland homeland = db.MyHomelands.Find(id);
            if (homeland == null)
            {
                return HttpNotFound();
            }
            return View(homeland);
        }

        // GET: Homelands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homelands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HomelandId,HomelandName")] Homeland homeland)
        {
            if (ModelState.IsValid)
            {
                db.MyHomelands.Add(homeland);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeland);
        }

        // GET: Homelands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homeland homeland = db.MyHomelands.Find(id);
            if (homeland == null)
            {
                return HttpNotFound();
            }
            return View(homeland);
        }

        // POST: Homelands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HomelandId,HomelandName")] Homeland homeland)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeland).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeland);
        }

        // GET: Homelands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homeland homeland = db.MyHomelands.Find(id);
            if (homeland == null)
            {
                return HttpNotFound();
            }
            return View(homeland);
        }

        // POST: Homelands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homeland homeland = db.MyHomelands.Find(id);
            db.MyHomelands.Remove(homeland);
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
