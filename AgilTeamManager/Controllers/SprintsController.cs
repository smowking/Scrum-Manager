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
    public class SprintsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Sprints
        public ActionResult Index()
        {
            return View(db.Sprints.ToList());
        }

        // GET: Sprints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprint sprint = db.Sprints.Find(id);
            if (sprint == null)
            {
                return HttpNotFound();
            }
            return View(sprint);
        }

        // GET: Sprints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sprints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataInicio,DataFim")] Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                db.Sprints.Add(sprint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sprint);
        }

        // GET: Sprints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SprintViewModel sprintViewModel = new SprintViewModel();
            sprintViewModel.Sprint = db.Sprints.Find(id);

            if (sprintViewModel.Sprint == null)
            {
                return HttpNotFound();
            }

            List<Historia> historiasDoSprint = new List<Historia>();
            List<Historia> llstHistorias = db.Historias.AsNoTracking().ToList();
            List<SprintAuxiliar> historiasSprintAtualAux = db.SprintAuxiliar.AsNoTracking().Where(c=> c.SprintId == sprintViewModel.Sprint.Id).ToList();

            historiasSprintAtualAux.ForEach(historiaAux =>
            {
                sprintViewModel.ScrumBoardViewModel.HistoriasDoSprint.Add(llstHistorias.Where(c => c.Id == historiaAux.HistoriaId).SingleOrDefault());
            });

            sprintViewModel.ScrumBoardViewModel.Historias = llstHistorias.Where(c => c.DataTermino == null).Except(sprintViewModel.ScrumBoardViewModel.HistoriasDoSprint).ToList();

            return View(sprintViewModel);
        }

        // POST: Sprints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataInicio,DataFim")] Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sprint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sprint);
        }

        // GET: Sprints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprint sprint = db.Sprints.Find(id);
            if (sprint == null)
            {
                return HttpNotFound();
            }
            return View(sprint);
        }

        // POST: Sprints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sprint sprint = db.Sprints.Find(id);
            db.Sprints.Remove(sprint);
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

        [HttpPost]
        public JsonResult AlterBoard(int historiaId, int? boardId, int sprintId)
        {
            try
            {
                SprintAuxiliar sprintAuxiliar = db.SprintAuxiliar.FirstOrDefault(c => c.HistoriaId == historiaId && c.SprintId == sprintId);

                if (boardId == 0)
                {

                    if (sprintAuxiliar != null)
                    {
                        db.SprintAuxiliar.Remove(sprintAuxiliar);
                        db.SaveChanges();
                    }
                    return Json(new { MessageType = "Success", Message = "História movida com sucesso!" }, new JsonRequestBehavior());
                }
                else if (boardId == 1)
                {
                    if (sprintAuxiliar == null)
                    {
                        sprintAuxiliar = new SprintAuxiliar();

                        sprintAuxiliar.HistoriaId = historiaId;
                        sprintAuxiliar.SprintId = sprintId;

                        db.SprintAuxiliar.Add(sprintAuxiliar);
                        db.SaveChanges();
                    }
                    return Json(new { MessageType = "Success", Message = "História movida com sucesso!" }, new JsonRequestBehavior());
                }

                return Json(new { MessageType = "Error", Message = "Não foi possível mover historia de lugar." }, new JsonRequestBehavior());
            }
            catch (Exception ex)
            {
                return Json(new { MessageType = "Error", Message = "Não foi possível mover historia de lugar." }, new JsonRequestBehavior());
            }
        }
    }
}
