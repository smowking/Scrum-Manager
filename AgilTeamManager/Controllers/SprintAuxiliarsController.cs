using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgilTeamManager.Core.Models;
using AgilTeamManager.Data.Contexto;

namespace AgilTeamManager.Controllers
{
    public class SprintAuxiliarsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: SprintAuxiliars
        public ActionResult Index()
        {
            return View(db.SprintAuxiliar.ToList());
        }

        // GET: SprintAuxiliars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SprintAuxiliar sprintAuxiliar = db.SprintAuxiliar.Find(id);
            if (sprintAuxiliar == null)
            {
                return HttpNotFound();
            }
            return View(sprintAuxiliar);
        }

        // GET: SprintAuxiliars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SprintAuxiliars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HistoriaId,SprintId")] SprintAuxiliar sprintAuxiliar)
        {
            if (ModelState.IsValid)
            {
                db.SprintAuxiliar.Add(sprintAuxiliar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sprintAuxiliar);
        }

        // GET: SprintAuxiliars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SprintAuxiliar sprintAuxiliar = db.SprintAuxiliar.Find(id);
            if (sprintAuxiliar == null)
            {
                return HttpNotFound();
            }
            return View(sprintAuxiliar);
        }

        // POST: SprintAuxiliars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HistoriaId,SprintId")] SprintAuxiliar sprintAuxiliar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sprintAuxiliar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sprintAuxiliar);
        }

        // GET: SprintAuxiliars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SprintAuxiliar sprintAuxiliar = db.SprintAuxiliar.Find(id);
            if (sprintAuxiliar == null)
            {
                return HttpNotFound();
            }
            return View(sprintAuxiliar);
        }

        // POST: SprintAuxiliars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SprintAuxiliar sprintAuxiliar = db.SprintAuxiliar.Find(id);
            db.SprintAuxiliar.Remove(sprintAuxiliar);
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
