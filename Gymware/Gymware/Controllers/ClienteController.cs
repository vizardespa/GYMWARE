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
    public class ClienteController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Gimnasio);
            ViewBag.NombresGimnasios = db.Curso.Select(c => c.Gimnasio.Nombre).Distinct();
            return View(cliente.ToList());
        }

        [HttpPost]
        public ActionResult Index(string NombreCliente, string NombreGym)
        {
            var cliente = db.Cliente.Include(c => c.Gimnasio);
            ViewBag.NombresGimnasios = db.Curso.Select(c => c.Gimnasio.Nombre).Distinct();
            return View(cliente.Select(c => c).Where(c => c.Nombre.Contains(NombreCliente)/*&&c.Gimnasio.Nombre.Contains(NombreGym ?? "")*/).ToList());
        }
        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre");
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", cliente.IdGimnasio);
            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", cliente.IdGimnasio);
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", cliente.IdGimnasio);
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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