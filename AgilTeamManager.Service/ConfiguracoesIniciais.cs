using AgilTeamManager.Core.Models;
using AgilTeamManager.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AgilTeamManager.Service
{
    public class ConfiguracoesIniciais
    {
        private Contexto db = new Contexto();

        public void AdicionaPrimeiraConfig()
        {
            if (!db.Config.Any())
            {
                Configuracao config = new Configuracao();
                config.Lingua = "pt-br";
                config.DuracaoDiasSprint = 15;
                db.Config.Add(config);
                db.SaveChanges();
            }
        }

        public void AdicionarEventosPadroes()
        {
            if (!db.Eventos.Any())
            {
                SprintService sprintService = new SprintService();
                Sprint sprintAtual = sprintService.RetornaUltimoSprint();

                Evento eventoInicial = new Evento();
                Evento eventoFinal = new Evento();

                eventoInicial.Fixo = "S";
                eventoInicial.Descricao = "Marco inicial do sprint";
                eventoInicial.DataEvento = sprintAtual.DataInicio;
                eventoFinal.Fixo = "S";
                eventoFinal.Descricao = "Marco final do sprint";
                eventoFinal.DataEvento = sprintAtual.DataFim;

                db.Eventos.Add(eventoInicial);
                db.Eventos.Add(eventoFinal);
                db.SaveChanges();
            }

        }

        public void SetarLinguagemDoSistema()
        {
            Configuracao config = db.Config.FirstOrDefault();

            if (config != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(config.Lingua);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(config.Lingua);
            }
        }

    }
}
