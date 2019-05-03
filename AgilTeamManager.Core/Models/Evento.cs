using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public int? SprintId { get; set; }
        public DateTime DataEvento { get; set; }
        public string Descricao { get; set; }
        public string Fixo { get; set; }

        [NotMapped]
        public double PorcentagemSprint { get; set; }
    }
}
