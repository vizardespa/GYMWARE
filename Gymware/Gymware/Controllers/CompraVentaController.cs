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
    public class CompraVentaController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /CompraVenta/

        public ActionResult Index()
        {
            return View(db.CompraVenta.ToList());
        }

        //
        // GET: /CompraVenta/Details/5

        public ActionResult Details(int id = 0)
        {
            CompraVenta compraventa = db.CompraVenta.Find(id);
            if (compraventa == null)
            {
                return HttpNotFound();
            }
            return View(compraventa);
        }

        //
        // GET: /CompraVenta/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CompraVenta/Create

        [HttpPost]
        public ActionResult Create(CompraVenta compraventa)
        {
            if (ModelState.IsValid)
            {
                db.CompraVenta.Add(compraventa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compraventa);
        }

        //
        // GET: /CompraVenta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CompraVenta compraventa = db.CompraVenta.Find(id);
            if (compraventa == null)
            {
                return HttpNotFound();
            }
            return View(compraventa);
        }

        //
        // POST: /CompraVenta/Edit/5

        [HttpPost]
        public ActionResult Edit(CompraVenta compraventa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraventa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compraventa);
        }

        //
        // GET: /CompraVenta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CompraVenta compraventa = db.CompraVenta.Find(id);
            if (compraventa == null)
            {
                return HttpNotFound();
            }
            return View(compraventa);
        }

        //
        // POST: /CompraVenta/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraVenta compraventa = db.CompraVenta.Find(id);
            db.CompraVenta.Remove(compraventa);
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