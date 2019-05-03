using AgilTeamManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Data.Contexto
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<ScrumBoardColunas> ScrumBoardColunas { get; set; }
        public DbSet<SprintAuxiliar> SprintAuxiliar { get; set; }
        public DbSet<Configuracao> Config { get; set; }
        public DbSet<HistoriaHistorico> HistoriaHistorico { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<AgilTeamManager.Core.Models.Sprint> Sprints { get; set; }
    }
}
