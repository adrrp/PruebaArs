using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaArs.Models;

namespace PruebaArs.Controllers
{
    public class AfiliadoesController : Controller
    {
        private Afiliados_Adrian_PadillaEntities db = new Afiliados_Adrian_PadillaEntities();

        // GET: Afiliadoes
        public ActionResult Index()
        {
            var afiliados = db.Afiliados.Include(a => a.Estatu).Include(a => a.Plane);
            return View(afiliados.ToList());
        }

        // GET: Afiliadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // GET: Afiliadoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Estatus = new SelectList(db.Estatus, "Estatus", "Estatus");
            ViewBag.Id_Plan = new SelectList(db.Planes, "Planes", "Estatus");
            return View();
        }

        // POST: Afiliadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Afiliados,Nombres_Afiliados,Apellidos_Afiliados,Fecha_Registro,MConsumido,Id_Estatus,Id_Plan")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Afiliados.Add(afiliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Estatus = new SelectList(db.Estatus, "Estatus", "Estatus", afiliado.Id_Estatus);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Planes", "Estatus", afiliado.Id_Plan);
            return View(afiliado);
        }

        // GET: Afiliadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Estatus = new SelectList(db.Estatus, "Estatus", "Estatus", afiliado.Id_Estatus);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Planes", "Estatus", afiliado.Id_Plan);
            return View(afiliado);
        }

        // POST: Afiliadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Afiliados,Nombres_Afiliados,Apellidos_Afiliados,Fecha_Registro,MConsumido,Id_Estatus,Id_Plan")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afiliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Estatus = new SelectList(db.Estatus, "Estatus", "Estatus", afiliado.Id_Estatus);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Planes", "Estatus", afiliado.Id_Plan);
            return View(afiliado);
        }

        // GET: Afiliadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afiliado afiliado = db.Afiliados.Find(id);
            db.Afiliados.Remove(afiliado);
            db.SaveChanges();
            return RedirectToAction("Index");
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
