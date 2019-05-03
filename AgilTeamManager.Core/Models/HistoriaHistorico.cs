using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.Models
{
    public class HistoriaHistorico
    {
        public HistoriaHistorico()
        {
                
        }

        public HistoriaHistorico(int id, int historiaId, string descricao, int usuarioId, int? sprintId)
        {
            Id = id;
            HistoriaId = historiaId;
            Descricao = descricao;
            UsuarioId = usuarioId;
            SprintId = sprintId;
        }

        public int Id { get; set; }
        public int HistoriaId { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int? SprintId { get; set; }
    }
}

//Id HistoriaId  Descricao UsuarioId  Data SprintId