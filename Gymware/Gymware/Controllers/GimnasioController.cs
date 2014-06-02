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
    public class GimnasioController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Gimnasio/

        public ActionResult Index()
        {
            return View(db.Gimnasio.ToList());
        }

        [HttpPost]
        public ActionResult Index(string Nombre, string Direccion)
        {

            return View(db.Gimnasio.Select(x=>x).Where(x=>x.Nombre.ToUpper().Contains(Nombre.ToUpper()??"")&&x.Direccion.ToUpper().Contains(Direccion.ToUpper()??"")).ToList());
        }

        
        //
        // GET: /Gimnasio/Details/5

        public ActionResult Details(int id = 0)
        {
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            if (gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(gimnasio);
        }

        //
        // GET: /Gimnasio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gimnasio/Create

        [HttpPost]
        public ActionResult Create(Gimnasio gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Gimnasio.Add(gimnasio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gimnasio);
        }

        //
        // GET: /Gimnasio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            if (gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(gimnasio);
        }

        //
        // POST: /Gimnasio/Edit/5

        [HttpPost]
        public ActionResult Edit(Gimnasio gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gimnasio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gimnasio);
        }

        //
        // GET: /Gimnasio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            if (gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(gimnasio);
        }

        //
        // POST: /Gimnasio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            db.Gimnasio.Remove(gimnasio);
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