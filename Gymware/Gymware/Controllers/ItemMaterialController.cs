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
    public class ItemMaterialController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /ItemMaterial/

        public ActionResult Index()
        {
            var itemmaterial = db.ItemMaterial.Include(i => i.Material);
            return View(itemmaterial.ToList());
        }

        //
        // GET: /ItemMaterial/Details/5

        public ActionResult Details(int id = 0)
        {
            ItemMaterial itemmaterial = db.ItemMaterial.Find(id);
            if (itemmaterial == null)
            {
                return HttpNotFound();
            }
            return View(itemmaterial);
        }

        //
        // GET: /ItemMaterial/Create

        public ActionResult Create()
        {
            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Nombre");
            return View();
        }

        //
        // POST: /ItemMaterial/Create

        [HttpPost]
        public ActionResult Create(ItemMaterial itemmaterial)
        {
            if (ModelState.IsValid)
            {
                db.ItemMaterial.Add(itemmaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Nombre", itemmaterial.IdMaterial);
            return View(itemmaterial);
        }

        //
        // GET: /ItemMaterial/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ItemMaterial itemmaterial = db.ItemMaterial.Find(id);
            if (itemmaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Nombre", itemmaterial.IdMaterial);
            return View(itemmaterial);
        }

        //
        // POST: /ItemMaterial/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemMaterial itemmaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemmaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Nombre", itemmaterial.IdMaterial);
            return View(itemmaterial);
        }

        //
        // GET: /ItemMaterial/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ItemMaterial itemmaterial = db.ItemMaterial.Find(id);
            if (itemmaterial == null)
            {
                return HttpNotFound();
            }
            return View(itemmaterial);
        }

        //
        // POST: /ItemMaterial/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemMaterial itemmaterial = db.ItemMaterial.Find(id);
            db.ItemMaterial.Remove(itemmaterial);
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