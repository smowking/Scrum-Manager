using AgilTeamManager.Core.Models;
using AgilTeamManager.Core.ViewModel;
using AgilTeamManager.Data.Contexto;
using AgilTeamManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgilTeamManager.Controllers
{
    public class KanbanBoardController : Controller
    {
        private Contexto db = new Contexto();

        // GET: ScrumBoard
        public ActionResult Index()
        {
            ScrumBoardViewModel scrumBoardViewModel = new ScrumBoardViewModel();
            SprintService sprintService = new SprintService();
            Sprint sprintAtual = sprintService.RetornaUltimoSprint();
            List<SprintAuxiliar> sprintAuxiliars = db.SprintAuxiliar.AsNoTracking().Where(c => c.SprintId == sprintAtual.Id).ToList();
            scrumBoardViewModel.Sprint = sprintAtual;

            sprintAuxiliars.ForEach(historiaAux =>
            {
                scrumBoardViewModel.Historias.Add(db.Historias.SingleOrDefault(c => c.Id == historiaAux.HistoriaId));
            });

            scrumBoardViewModel.ColunasScrum = db.ScrumBoardColunas.AsNoTracking().OrderBy(c => c.Ordem).ToList();

            return View(scrumBoardViewModel);
        }

        [HttpPost]
        public JsonResult AlterBoard(int historiaId, int? boardId)
        {
            try
            {
                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
                Historia historia = db.Historias.Find(historiaId);
                HistoriaHistorico ultimoHistorico = db.HistoriaHistorico.ToList().Last(c => c.HistoriaId == historia.Id);

                if (idUsu != ultimoHistorico.UsuarioId && historia.ScrumBoardColunasId != null)
                    return Json(new { MessageType = "Fail", Message = "Você não pode alterar uma história que não é sua." }, new JsonRequestBehavior());


                Usuario usuario = db.Usuarios.Find(idUsu);
                historia.ScrumBoardColunasId = (boardId == 0) ? null : boardId;

                if (usuario != null && historia.ScrumBoardColunasId != null)
                {
                    historia.FotoDesenvolvedor = "data:image;base64," + Convert.ToBase64String(usuario.ProfilePicture);
                    historia.IdDesenvolvedorResponsavel = usuario.Id;

                    string description = string.Format(Resources.Resources.LogHistoriaBoard, idUsu, usuario.Nome, historia.Id, historia.ScrumBoardColunasId, DateTime.Now);
                    HistoriaHistorico historico = new HistoriaHistorico(0, historia.Id, description, usuario.Id, null);
                    db.HistoriaHistorico.Add(historico);
                    db.SaveChanges();

                }
                else
                {
                    historia.FotoDesenvolvedor = string.Empty;
                    historia.IdDesenvolvedorResponsavel = null;

                    string description = string.Format(Resources.Resources.LogHistoriaBoard, idUsu, usuario.Nome, historia.Id, "Backlog", DateTime.Now);
                    HistoriaHistorico historico = new HistoriaHistorico(0, historia.Id, description, usuario.Id, null);
                    db.HistoriaHistorico.Add(historico);
                    db.SaveChanges();
                }

                db.Entry(historia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Json(new { MessageType = "Success", Message = "História movida com sucesso!" }, new JsonRequestBehavior());
            }
            catch (Exception ex)
            {
                return Json(new { MessageType = "Error", Message = "Não foi possível mover historia de lugar." }, new JsonRequestBehavior());
            }
        }

        public ActionResult HistoriaDetalhes(int historiaId)
        {
            if (Request.IsAjaxRequest())
            {
                Historia historia = db.Historias.Find(historiaId);

                if (historia != null)
                    return PartialView(historia);
                else
                {
                    Response.StatusCode = 403;
                    return PartialView("Error");
                }
            }

            Response.StatusCode = 500;
            return PartialView("Error");
        }

        public JsonResult PaperBeforePost(int historiaId, int? boardId)
        {
            int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
            Historia historia = db.Historias.Find(historiaId);
            HistoriaHistorico ultimoHistorico = db.HistoriaHistorico.ToList().Last(c => c.HistoriaId == historia.Id);

            if (idUsu != ultimoHistorico.UsuarioId && historia.ScrumBoardColunasId != null)
                return Json(new { MessageType = "Fail", Message = "Você não pode alterar uma história que não é sua." }, new JsonRequestBehavior());

            return Json(new { MessageType = "Success", Message = "Success." }, new JsonRequestBehavior());
        }
    }
}