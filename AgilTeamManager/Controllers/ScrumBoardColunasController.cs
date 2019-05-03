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
    public class ScrumBoardColunasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: ScrumBoardColunas
        public ActionResult Index()
        {
            return View(db.ScrumBoardColunas.ToList());
        }

        // GET: ScrumBoardColunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumBoardColunas scrumBoardColunas = db.ScrumBoardColunas.Find(id);
            if (scrumBoardColunas == null)
            {
                return HttpNotFound();
            }
            return View(scrumBoardColunas);
        }

        // GET: ScrumBoardColunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScrumBoardColunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Ordem")] ScrumBoardColunas scrumBoardColunas)
        {
            if (ModelState.IsValid)
            {
                db.ScrumBoardColunas.Add(scrumBoardColunas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scrumBoardColunas);
        }

        // GET: ScrumBoardColunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumBoardColunas scrumBoardColunas = db.ScrumBoardColunas.Find(id);
            if (scrumBoardColunas == null)
            {
                return HttpNotFound();
            }
            return View(scrumBoardColunas);
        }

        // POST: ScrumBoardColunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Ordem")] ScrumBoardColunas scrumBoardColunas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrumBoardColunas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scrumBoardColunas);
        }

        // GET: ScrumBoardColunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumBoardColunas scrumBoardColunas = db.ScrumBoardColunas.Find(id);
            if (scrumBoardColunas == null)
            {
                return HttpNotFound();
            }
            return View(scrumBoardColunas);
        }

        // POST: ScrumBoardColunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScrumBoardColunas scrumBoardColunas = db.ScrumBoardColunas.Find(id);
            db.ScrumBoardColunas.Remove(scrumBoardColunas);
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
