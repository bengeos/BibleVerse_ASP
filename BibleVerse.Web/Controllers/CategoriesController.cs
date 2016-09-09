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
    public class CategoriesController : Controller
    {
        private BibleVerseDatabaseContext db = new BibleVerseDatabaseContext();

        // GET: /Categories/
        public ActionResult Index()
        {
            
            return View(db.Categories.ToList());
        }
        public JsonResult Update()
        {
            var xx = db.Categories.ToList();

            List<Verse> verses = new List<Verse>();
            foreach (Verse v in db.Verses) {
                Verse vv = new Verse();
                vv.ID = v.ID;
                vv.CategoryID = v.CategoryID;
                vv.Body = v.Body;
                vv.Verse1 = v.Verse1;
                verses.Add(vv);
            }
            List<Category> categories = new List<Category>();
            foreach (Category cat in db.Categories)
            {
                Category cc = new Category();
                cc.ID = cat.ID;
                cc.Name = cat.Name;
                categories.Add(cc);
            }
            Bible_Verse bb = new Bible_Verse();
            bb.Categories = categories;
            bb.Verses = verses;
            return Json(bb,JsonRequestBehavior.AllowGet);
        }

        // GET: /Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: /Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: /Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
