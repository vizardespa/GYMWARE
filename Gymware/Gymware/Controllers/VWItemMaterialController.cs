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
    public class VWItemMaterialController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /VWItemMaterial/

        public ActionResult Index()
        {
            return View(db.VW_ItemMaterial.ToList());
        }

        //
        // GET: /VWItemMaterial/Details/5

        public ActionResult Details(string id = null)
        {
            VW_ItemMaterial vw_itemmaterial = db.VW_ItemMaterial.Find(id);
            if (vw_itemmaterial == null)
            {
                return HttpNotFound();
            }
            return View(vw_itemmaterial);
        }

        //
        // GET: /VWItemMaterial/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VWItemMaterial/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VW_ItemMaterial vw_itemmaterial)
        {
            if (ModelState.IsValid)
            {
                db.VW_ItemMaterial.Add(vw_itemmaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_itemmaterial);
        }

        //
        // GET: /VWItemMaterial/Edit/5

        public ActionResult Edit(string id = null)
        {
            VW_ItemMaterial vw_itemmaterial = db.VW_ItemMaterial.Find(id);
            if (vw_itemmaterial == null)
            {
                return HttpNotFound();
            }
            return View(vw_itemmaterial);
        }

        //
        // POST: /VWItemMaterial/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VW_ItemMaterial vw_itemmaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_itemmaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_itemmaterial);
        }

        //
        // GET: /VWItemMaterial/Delete/5

        public ActionResult Delete(string id = null)
        {
            VW_ItemMaterial vw_itemmaterial = db.VW_ItemMaterial.Find(id);
            if (vw_itemmaterial == null)
            {
                return HttpNotFound();
            }
            return View(vw_itemmaterial);
        }

        //
        // POST: /VWItemMaterial/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VW_ItemMaterial vw_itemmaterial = db.VW_ItemMaterial.Find(id);
            db.VW_ItemMaterial.Remove(vw_itemmaterial);
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