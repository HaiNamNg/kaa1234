using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    
    public class HocTapsController : Controller
    {
        private DemoDBContext db = new DemoDBContext();

        // GET: HocTaps
        public ActionResult Index()
        {
            var hocTaps = db.HocTaps.Include(h => h.Lop);
            return View(hocTaps.ToList());
        }

        // GET: HocTaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocTap hocTap = db.HocTaps.Find(id);
            if (hocTap == null)
            {
                return HttpNotFound();
            }
            return View(hocTap);
        }

        // GET: HocTaps/Create
        public ActionResult Create()
        {
            ViewBag.TenLop = new SelectList(db.Lops, "MaLop", "TenLop");
            return View();
        }

        // POST: HocTaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoVaTen,MaSinhVien,TenLop")] HocTap hocTap)
        {
            if (ModelState.IsValid)
            {
                db.HocTaps.Add(hocTap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenLop = new SelectList(db.Lops, "MaLop", "TenLop", hocTap.TenLop);
            return View(hocTap);
        }
        
        // GET: HocTaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocTap hocTap = db.HocTaps.Find(id);
            if (hocTap == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenLop = new SelectList(db.Lops, "MaLop", "TenLop", hocTap.TenLop);
            return View(hocTap);
        }

        // POST: HocTaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HoVaTen,MaSinhVien,TenLop")] HocTap hocTap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocTap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenLop = new SelectList(db.Lops, "MaLop", "TenLop", hocTap.TenLop);
            return View(hocTap);
        }
        [Authorize]
        // GET: HocTaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocTap hocTap = db.HocTaps.Find(id);
            if (hocTap == null)
            {
                return HttpNotFound();
            }
            return View(hocTap);
        }

        // POST: HocTaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HocTap hocTap = db.HocTaps.Find(id);
            db.HocTaps.Remove(hocTap);
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
