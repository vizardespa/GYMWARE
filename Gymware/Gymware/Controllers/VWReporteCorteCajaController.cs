﻿using System;
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
    public class VWReporteCorteCajaController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /VWReporteCorteCaja/

        public ActionResult Index()
        {
            return View(db.VW_ReporteCorteCaja.ToList());
        }

        //
        // GET: /VWReporteCorteCaja/Details/5

        public ActionResult Details(string id = null)
        {
            VW_ReporteCorteCaja vw_reportecortecaja = db.VW_ReporteCorteCaja.Find(id);
            if (vw_reportecortecaja == null)
            {
                return HttpNotFound();
            }
            return View(vw_reportecortecaja);
        }

        //
        // GET: /VWReporteCorteCaja/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VWReporteCorteCaja/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VW_ReporteCorteCaja vw_reportecortecaja)
        {
            if (ModelState.IsValid)
            {
                db.VW_ReporteCorteCaja.Add(vw_reportecortecaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_reportecortecaja);
        }

        //
        // GET: /VWReporteCorteCaja/Edit/5

        public ActionResult Edit(string id = null)
        {
            VW_ReporteCorteCaja vw_reportecortecaja = db.VW_ReporteCorteCaja.Find(id);
            if (vw_reportecortecaja == null)
            {
                return HttpNotFound();
            }
            return View(vw_reportecortecaja);
        }

        //
        // POST: /VWReporteCorteCaja/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VW_ReporteCorteCaja vw_reportecortecaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_reportecortecaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_reportecortecaja);
        }

        //
        // GET: /VWReporteCorteCaja/Delete/5

        public ActionResult Delete(string id = null)
        {
            VW_ReporteCorteCaja vw_reportecortecaja = db.VW_ReporteCorteCaja.Find(id);
            if (vw_reportecortecaja == null)
            {
                return HttpNotFound();
            }
            return View(vw_reportecortecaja);
        }

        //
        // POST: /VWReporteCorteCaja/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VW_ReporteCorteCaja vw_reportecortecaja = db.VW_ReporteCorteCaja.Find(id);
            db.VW_ReporteCorteCaja.Remove(vw_reportecortecaja);
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