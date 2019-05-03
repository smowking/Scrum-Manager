using AgilTeamManager.Core.Models;
using AgilTeamManager.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgilTeamManager.Core.ViewModel;
using AgilTeamManager.Service;

namespace AgilTeamManager.Controllers
{
    public class HomeController : Controller
    {

        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            DashboardViewModel dashboardVM = new DashboardViewModel();

            SprintService sprintService = new SprintService();
            dashboardVM.Sprint = sprintService.RetornaUltimoSprint();
            dashboardVM.Eventos = db.Eventos.Where(c => c.SprintId == dashboardVM.Sprint.Id || c.Fixo == "S").ToList();


            int dias = dashboardVM.Sprint.DataFim.Subtract(dashboardVM.Sprint.DataInicio).Days;
            for (int i = 0; i < dias; i++)
            {
                dashboardVM.DiasSprint.Add(dashboardVM.Sprint.DataInicio.AddDays(i));
            }

            foreach (var dashboardVmEvento in dashboardVM.Eventos)
            {
                DateTime dataFinal = dashboardVM.Sprint.DataFim;
                int tmSpanTotal = dashboardVM.Sprint.DataFim.Subtract(dashboardVM.Sprint.DataInicio).Days;
                int tmSpan = tmSpanTotal - (dashboardVM.Sprint.DataFim.Subtract(dashboardVmEvento.DataEvento).Days);



                dashboardVmEvento.PorcentagemSprint = Convert.ToInt32(((double)tmSpan/ (double)tmSpanTotal)*100);
            }

            return View(dashboardVM);
        }

        public ActionResult Login(Usuario u)
        {

            var v = db.Usuarios.Where(a => a.Login.Equals(u.Login) && a.Password.Equals(u.Password)).FirstOrDefault();

            //Image image = Image.FromFile("D:\victor.jpg");
            //var ms = new MemoryStream();
            //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //var bytes = ms.ToArray();

            if (v != null)
            {
                Session["USUARIO_ID"] = v.Id.ToString();
                Session["USUARIO_NOME"] = v.Nome.ToString();

                Session["USUARIO_FOTO"] = (v.ProfilePicture != null) ? "data:image;base64," + Convert.ToBase64String(v.ProfilePicture) : "";

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["USUARIO_ID"] = null;
            Session["USUARIO_NOME"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}