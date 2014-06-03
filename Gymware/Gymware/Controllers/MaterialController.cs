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
    public class MaterialController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Material/

        public ActionResult Index()
        {
            ViewBag.Marcas = db.Material.Select(x => x.Marca).Distinct();
            return View(db.Material.ToList());
        }

        [HttpPost]
        public ActionResult Index(string Nombre, string Modelo, string Marca)
        {
            ViewBag.Marcas = db.Material.Select(x => x.Marca).Distinct();
            return View(db.Material.Select(x=>x).Where(x=>x.Nombre.Contains(Nombre)&&x.Modelo.Contains(Modelo)&&
                x.Marca.Contains(Marca)).ToList());
        }
        //
        // GET: /Material/Details/5

        public ActionResult Details(int id = 0)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        //
        // GET: /Material/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Material/Create

        [HttpPost]
        public ActionResult Create(Material material)
        {
            if (ModelState.IsValid)
            {
                db.Material.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(material);
        }

        //
        // GET: /Material/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        //
        // POST: /Material/Edit/5

        [HttpPost]
        public ActionResult Edit(Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(material);
        }

        //
        // GET: /Material/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        //
        // POST: /Material/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Material.Find(id);
            db.Material.Remove(material);
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