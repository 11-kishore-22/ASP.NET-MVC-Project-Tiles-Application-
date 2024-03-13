using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ganesh_tiles.Model;

namespace Ganesh_tiles.Controllers
{
    public class ContactController : Controller
    {
        private GT_MVCEntities1 db = new GT_MVCEntities1();

        // GET: Contact
        public ActionResult Index()
        {
            return View(db.tbl_Contact.ToList());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Contact tbl_Contact = db.tbl_Contact.Find(id);
            if (tbl_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Contact);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Message")] tbl_Contact tbl_Contact)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Contact.Add(tbl_Contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Contact);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Contact tbl_Contact = db.tbl_Contact.Find(id);
            if (tbl_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Message")] tbl_Contact tbl_Contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Contact);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Contact tbl_Contact = db.tbl_Contact.Find(id);
            if (tbl_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Contact tbl_Contact = db.tbl_Contact.Find(id);
            db.tbl_Contact.Remove(tbl_Contact);
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
