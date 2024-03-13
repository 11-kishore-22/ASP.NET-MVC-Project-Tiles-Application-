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
    public class tbl_AdminController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_Admin
        public ActionResult Index()
        {
            return View(db.tbl_Admin.ToList());
        }

        // GET: tbl_Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Admin tbl_Admin = db.tbl_Admin.Find(id);
            if (tbl_Admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Admin);
        }

        // GET: tbl_Admin/Create
        public ActionResult Admin()
        {
            return View();
        }

        // POST: tbl_Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin([Bind(Include = "Id,Name,Password")] tbl_Admin tbl_Admin)
        {
            
                //using(Model1 md = new Model1())
                //{

                    //This is the linear integrated query for validation

                    //var result = md.tbl_Admin.Where(e => e.Name.Equals(tbl_Admin.Name) &&
                    //                                    e.Password.Equals(tbl_Admin.Password)).FirstOrDefault();
                    //if(result != null)
                    //{
                    //    return RedirectToAction("Dashboard","Dashboard");

                    //}
                    //else
                    //{
                    //    ModelState.AddModelError("","Your are not a Admin");
                    //}

                    if (ModelState.IsValid)
                    {
                        using (Model1 md = new Model1())
                        {
                            var result = md.tbl_Admin.Where(e => e.Name.Equals(tbl_Admin.Name) &&
                                                            e.Password.Equals(tbl_Admin.Password)).FirstOrDefault();
                            return RedirectToAction("Dashboard", "Dashboard");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Admin credentials");
                    }
                //}
            

            return View(tbl_Admin);
        }

        // GET: tbl_Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Admin tbl_Admin = db.tbl_Admin.Find(id);
            if (tbl_Admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Admin);
        }

        // POST: tbl_Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password")] tbl_Admin tbl_Admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Admin);
        }

        // GET: tbl_Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Admin tbl_Admin = db.tbl_Admin.Find(id);
            if (tbl_Admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Admin);
        }

        // POST: tbl_Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Admin tbl_Admin = db.tbl_Admin.Find(id);
            db.tbl_Admin.Remove(tbl_Admin);
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
