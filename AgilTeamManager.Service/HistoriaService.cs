using AgilTeamManager.Core.Models;
using AgilTeamManager.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Service
{
    public static class HistoriaService
    {
        public static Contexto db = new Contexto();

        public static string RetornarNomeDesenvolvedorPorID(int id)
        {
            Recurso dev = db.Recursos.FirstOrDefault(c => c.Id == id);

            if (dev != null)
                return dev.Nome;
            else
                return "";
        }

        public static string RetornaFotoUsuario(int IdUsuario)
        {
            Usuario usuario = db.Usuarios.Find(IdUsuario);

            return "";
        }

        public static void AdicionaHistoricoHistoria(Historia historia, string resource, int idUsu)
        {
            Usuario usuario = db.Usuarios.Find(idUsu);

            string description = string.Format(resource, idUsu, usuario.Nome, historia.Id, DateTime.Now);
            HistoriaHistorico historico = new HistoriaHistorico(0, historia.Id, description, usuario.Id, null);
            db.HistoriaHistorico.Add(historico);
            db.SaveChanges();
        }
    }
}
