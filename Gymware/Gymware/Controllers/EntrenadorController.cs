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
    public class EntrenadorController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Entrenador/

        public ActionResult Index()
        {
            var entrenador = db.Entrenador.Include(e => e.Gimnasio);
            return View(entrenador.ToList());
        }

        //
        // GET: /Entrenador/Details/5

        public ActionResult Details(int id = 0)
        {
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        //
        // GET: /Entrenador/Create

        public ActionResult Create()
        {
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre");
            return View();
        }

        //
        // POST: /Entrenador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entrenador.Add(entrenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", entrenador.IdGimnasio);
            return View(entrenador);
        }

        //
        // GET: /Entrenador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", entrenador.IdGimnasio);
            return View(entrenador);
        }

        //
        // POST: /Entrenador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", entrenador.IdGimnasio);
            return View(entrenador);
        }

        //
        // GET: /Entrenador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        //
        // POST: /Entrenador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrenador entrenador = db.Entrenador.Find(id);
            db.Entrenador.Remove(entrenador);
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