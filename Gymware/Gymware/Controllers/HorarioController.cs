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
    public class HorarioController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Horario/

        public ActionResult Index()
        {
            var horario = db.Horario.Include(h => h.Curso).Include(h => h.Membresia);
            return View(horario.ToList());
        }

        //
        // GET: /Horario/Details/5

        public ActionResult Details(int id = 0)
        {
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        //
        // GET: /Horario/Create

        public ActionResult Create()
        {
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nombre");
            ViewBag.IdMembresia = new SelectList(db.Membresia, "IdMembresia", "Nombre");
            return View();
        }

        //
        // POST: /Horario/Create

        [HttpPost]
        public ActionResult Create(Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Horario.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nombre", horario.IdCurso);
            ViewBag.IdMembresia = new SelectList(db.Membresia, "IdMembresia", "Nombre", horario.IdMembresia);
            return View(horario);
        }

        //
        // GET: /Horario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nombre", horario.IdCurso);
            ViewBag.IdMembresia = new SelectList(db.Membresia, "IdMembresia", "Nombre", horario.IdMembresia);
            return View(horario);
        }

        //
        // POST: /Horario/Edit/5

        [HttpPost]
        public ActionResult Edit(Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nombre", horario.IdCurso);
            ViewBag.IdMembresia = new SelectList(db.Membresia, "IdMembresia", "Nombre", horario.IdMembresia);
            return View(horario);
        }

        //
        // GET: /Horario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        //
        // POST: /Horario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horario.Find(id);
            db.Horario.Remove(horario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult GetEvents(double start, double end)
        {
            var startDateTime = FromUnixTimestamp(start);
            var endDateTime = FromUnixTimestamp(end);
            //Conexion a la Base de Datos
            /*var events = from reps in context.CalEntries
                         where reps.StartDateTime > startDateTime && reps.EndDateTime < endDateTime
                         select reps;
            var clientList = new List<object>();

            foreach (var e in events)
            {
                clientList.Add(new
                {
                    id = e.CalEntriesId,
                    title = e.Description,
                    description = e.Description,
                    start = ConvertToTimestamp(e.StartDateTime),
                    end = ConvertToTimestamp(e.EndDateTime),
                    allDay = e.isAllDay,
                });
            } */
            return null/*Json(clientList.ToArray(), JsonRequestBehavior.AllowGet)*/;
        }

        private static DateTime FromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        /// <summary>
        /// convierte de DateTime a UNIX Timestamp
        /// summary>
        /// <param name="value">Date to convertparam>
        /// <returns>returns>
        private static double ConvertToTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            //return the total seconds (which is a UNIX timestamp)
            return (double)span.TotalSeconds;
        } 




    }
}