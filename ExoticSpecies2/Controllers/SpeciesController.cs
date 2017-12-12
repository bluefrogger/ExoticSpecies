/*
    Author: Alex Yoo
    Content: Species CRUD code. Custom partial view: _SpeciesForHomeland.
    Usage: ~/Species
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExoticSpeciesOfTheNorth.Models;

namespace ExoticSpeciesOfTheNorth.Controllers
{
    public class SpeciesController : Controller
    {
        private ExoticSpeciesDbContext db = new ExoticSpeciesDbContext();

        public PartialViewResult _IndexImages()
        {
            return PartialView();
        }

        // Custom partial view. Returns
        public PartialViewResult _SpeciesForHomeland(int homelandId)
        {
            var mySpecies = db.MySpecies.Where(ms => ms.HomelandId == homelandId);

            return PartialView(mySpecies.ToList());
        }

        // GET: Species
        public async Task<ActionResult> Index()
        {
            var mySpecies = db.MySpecies.Include(s => s.SpeciesHomeland);
            return View(await mySpecies.ToListAsync());
        }

        // GET: Species/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = await db.MySpecies.FindAsync(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // GET: Species/Create
        public ActionResult Create()
        {
            ViewBag.HomelandId = new SelectList(db.MyHomelands, "HomelandId", "HomelandName");
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SpeciesId,SpeciesName,HomelandId")] Species species)
        {
            if (ModelState.IsValid)
            {
                db.MySpecies.Add(species);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HomelandId = new SelectList(db.MyHomelands, "HomelandId", "HomelandName", species.HomelandId);
            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = await db.MySpecies.FindAsync(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomelandId = new SelectList(db.MyHomelands, "HomelandId", "HomelandName", species.HomelandId);
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SpeciesId,SpeciesName,HomelandId")] Species species)
        {
            if (ModelState.IsValid)
            {
                db.Entry(species).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HomelandId = new SelectList(db.MyHomelands, "HomelandId", "HomelandName", species.HomelandId);
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = await db.MySpecies.FindAsync(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Species species = await db.MySpecies.FindAsync(id);
            db.MySpecies.Remove(species);
            await db.SaveChangesAsync();
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
