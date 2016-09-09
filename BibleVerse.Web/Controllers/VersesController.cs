using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibleVerse.Web.Models;

namespace BibleVerse.Web.Controllers
{
    public class VersesController : Controller
    {
        private BibleVerseDatabaseContext db = new BibleVerseDatabaseContext();

        // GET: /Verses/
        public ActionResult Index()
        {
            var verses = db.Verses.Include(v => v.Category);
            return View(verses.ToList());
        }

        // GET: /Verses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            return View(verse);
        }

        // GET: /Verses/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: /Verses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,CategoryID,Body,Verse1")] Verse verse)
        {
            if (ModelState.IsValid)
            {
                db.Verses.Add(verse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", verse.CategoryID);
            return View(verse);
        }

        // GET: /Verses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", verse.CategoryID);
            return View(verse);
        }

        // POST: /Verses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,CategoryID,Body,Verse1")] Verse verse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", verse.CategoryID);
            return View(verse);
        }

        // GET: /Verses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            return View(verse);
        }

        // POST: /Verses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verse verse = db.Verses.Find(id);
            db.Verses.Remove(verse);
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
