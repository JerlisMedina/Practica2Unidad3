using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pract2Unidad3.Models;

namespace Practica2Unidad3.Controllers
{
    public class PeliculasController : Controller
    {
        private PeliculasDBEntities db = new PeliculasDBEntities();

        // GET: Peliculas
        public ActionResult Index()
        {
            return View(db.TBL_PELICULA.ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            if (tBL_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PELICULA);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Titulo,Director,AutorPrincipal,No_Actores,Duracion,Estreno")] TBL_PELICULA tBL_PELICULA)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PELICULA.Add(tBL_PELICULA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_PELICULA);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            if (tBL_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PELICULA);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Titulo,Director,AutorPrincipal,No_Actores,Duracion,Estreno")] TBL_PELICULA tBL_PELICULA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PELICULA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_PELICULA);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            if (tBL_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PELICULA);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            db.TBL_PELICULA.Remove(tBL_PELICULA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Agregar metodo para listar las peliculas
        public ActionResult ListPeliculas() {
            return View(db.TBL_PELICULA.ToList());
        }

        // Agregar metodo para obtener un listado de las peliculas en formato JSON
        public JsonResult GetListJsonPeliculas() {
            ViewBag.Message = "Lista de Peliculas Formato JSON";
            return Json(ListPeliculas(),JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
