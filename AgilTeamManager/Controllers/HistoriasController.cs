using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgilTeamManager.Core.Models;
using AgilTeamManager.Core.ViewModel;
using AgilTeamManager.Data.Contexto;

namespace AgilTeamManager.Controllers
{
    public class HistoriasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Historias1
        public ActionResult Index()
        {
            List<Historia> historias = db.Historias.ToList();

            return View(historias);
        }

        // GET: Historias1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }

        // GET: Historias1/Create
        public ActionResult Create()
        {
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nome");
            ViewBag.ScrumBoardColunasId = new SelectList(db.ScrumBoardColunas, "Id", "Titulo");
            return View();
        }

        // POST: Historias1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,DataAbertura,RecursoId,ScrumBoardColunasId")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                db.Historias.Add(historia);
                db.SaveChanges();

                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
                Usuario usuario = db.Usuarios.Find(idUsu);

                string description = string.Format(Resources.Resources.LogHistoriaCreate, idUsu, usuario.Nome, historia.Id, DateTime.Now);
                HistoriaHistorico historico = new HistoriaHistorico(0, historia.Id, description, usuario.Id, null);
                db.HistoriaHistorico.Add(historico);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nome", historia.RecursoId);
            ViewBag.ScrumBoardColunasId = new SelectList(db.ScrumBoardColunas, "Id", "Titulo", historia.ScrumBoardColunasId);
            return View(historia);
        }



        // GET: Historias1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nome", historia.RecursoId);
            ViewBag.ScrumBoardColunasId = new SelectList(db.ScrumBoardColunas, "Id", "Titulo", historia.ScrumBoardColunasId);
            return View(historia);
        }

        // POST: Historias1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,DataAbertura,RecursoId,ScrumBoardColunasId")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nome", historia.RecursoId);
            ViewBag.ScrumBoardColunasId = new SelectList(db.ScrumBoardColunas, "Id", "Titulo", historia.ScrumBoardColunasId);
            return View(historia);
        }

        // GET: Historias1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }

        // POST: Historias1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historia historia = db.Historias.Find(id);
            db.Historias.Remove(historia);
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
