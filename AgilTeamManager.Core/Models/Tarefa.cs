using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        public Historia HistoriaId { get; set; }
        public int IdHistoria { get; set; }

        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Pontos { get; set; }
    }

}
