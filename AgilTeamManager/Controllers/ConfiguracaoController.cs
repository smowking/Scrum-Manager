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
    public class ConfiguracaoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Configuracao
        public ActionResult Index()
        {
            return RedirectToAction("Edit", 1);
        }


        // GET: Configuracao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuracao configuracao = db.Config.Find(id);
            if (configuracao == null)
            {
                return HttpNotFound();
            }
            return View(configuracao);
        }

        // POST: Configuracao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Lingua,DuracaoDiasSprint")] Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(configuracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = configuracao.Id});
            }
            return View(configuracao);
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
