using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gymware.Models;

namespace Gymware.Controllers
{
    public class UsuarioController : Controller
    {
        private GimnasioEntities db = new GimnasioEntities();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            //var usuario = db.Usuario.Include(u => u.Entrenador).Include(u => u.Gimnasio);
            //return View(usuario.ToList());
            return View();
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.IdEntrenador = new SelectList(db.Entrenador, "IdEntrenador", "Telefono");
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.IdEntrenador = new SelectList(db.Entrenador, "IdEntrenador", "Telefono", usuario.IdEntrenador);
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", usuario.IdGimnasio);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEntrenador = new SelectList(db.Entrenador, "IdEntrenador", "Telefono", usuario.IdEntrenador);
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", usuario.IdGimnasio);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.IdEntrenador = new SelectList(db.Entrenador, "IdEntrenador", "Telefono", usuario.IdEntrenador);
            ViewBag.IdGimnasio = new SelectList(db.Gimnasio, "IdGimnasio", "Nombre", usuario.IdGimnasio);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Login()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Login(Usuario user)
        {
            if (ModelState.IsValid)
            {
                if (Usuario.Login(user.NombreUsuario, user.Contraseña))
                {
                    FormsAuthentication.SetAuthCookie(user.NombreUsuario, false);
                    return RedirectToAction("Index", "Usuario");
                }
            }

            return View(user);
        }

        public ActionResult Logout(Usuario user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuario");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}