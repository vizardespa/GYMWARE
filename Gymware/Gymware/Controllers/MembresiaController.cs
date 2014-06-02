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
    public class MembresiaController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Membresia/

        public ActionResult Index()
        {
            var membresia = db.Membresia.Include(m => m.Gimnasio);
            return View(membresia.ToList());
        }

        [HttpPost]
        public ActionResult Index(string Nombre, string Fecha)
        {
            var membresia = db.Membresia.Include(m => m.Gimnasio);
            return View(membresia.ToList());
        }

        //
        // GET: /Membresia/Details/5

        public ActionResult Details(int id = 0)
        {
            Membresia membresia = db.Membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            return View(membresia);
        }

        //
        // GET: /Membresia/Create

        public ActionResult Create()
        {
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre");
            return View();
        }

        //
        // POST: /Membresia/Create

        [HttpPost]
        public ActionResult Create(Membresia membresia)
        {
            if (ModelState.IsValid)
            {
                db.Membresia.Add(membresia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", membresia.IdGimnasio);
            return View(membresia);
        }

        //
        // GET: /Membresia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Membresia membresia = db.Membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", membresia.IdGimnasio);
            return View(membresia);
        }

        //
        // POST: /Membresia/Edit/5

        [HttpPost]
        public ActionResult Edit(Membresia membresia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", membresia.IdGimnasio);
            return View(membresia);
        }

        //
        // GET: /Membresia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Membresia membresia = db.Membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            return View(membresia);
        }

        //
        // POST: /Membresia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Membresia membresia = db.Membresia.Find(id);
            db.Membresia.Remove(membresia);
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