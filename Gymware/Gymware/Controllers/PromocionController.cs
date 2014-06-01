using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymware.Models;

namespace Gymware.Controllers
{
    public class PromocionController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Promocion/

        public ActionResult Index()
        {
            return View(db.Promocion.ToList());
        }

        //
        // GET: /Promocion/Details/5

        public ActionResult Details(int id = 0)
        {
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        //
        // GET: /Promocion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Promocion/Create

        [HttpPost]
        public ActionResult Create(Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                db.Promocion.Add(promocion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promocion);
        }

        //
        // GET: /Promocion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        //
        // POST: /Promocion/Edit/5

        [HttpPost]
        public ActionResult Edit(Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocion);
        }

        //
        // GET: /Promocion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        //
        // POST: /Promocion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocion promocion = db.Promocion.Find(id);
            db.Promocion.Remove(promocion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}