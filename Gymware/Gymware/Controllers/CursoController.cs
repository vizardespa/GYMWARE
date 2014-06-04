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
    [Authorize]
    public class CursoController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Curso/

        public ActionResult Index()
        {
            var curso = db.Curso.Include(c => c.Gimnasio);
            ViewBag.NombresGimnasios = db.Curso.Select(c => c.Gimnasio.Nombre).Distinct();
            return View(curso.ToList());
        }

        [HttpPost]
        public ActionResult Index(string NombreCurso, string NombreGym)
        {
            var curso = db.Curso.Include(c => c.Gimnasio);
            ViewBag.NombresGimnasios = db.Curso.Select(c => c.Gimnasio.Nombre).Distinct();
            return View(curso.Select(c => c).Where(c => c.Nombre.Contains(NombreCurso)/* && c.Gimnasio.Nombre.Contains(NombreGym)*/).ToList());
        }

        //
        // GET: /Curso/Details/5

        public ActionResult Details(int id = 0)
        {
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // GET: /Curso/Create

        public ActionResult Create()
        {
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre");
            return View();
        }

        //
        // POST: /Curso/Create

        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Curso.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", curso.IdGimnasio);
            return View(curso);
        }

        //
        // GET: /Curso/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", curso.IdGimnasio);
            return View(curso);
        }

        //
        // POST: /Curso/Edit/5

        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", curso.IdGimnasio);
            return View(curso);
        }

        //
        // GET: /Curso/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // POST: /Curso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Curso.Find(id);
            db.Curso.Remove(curso);
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