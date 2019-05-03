using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.Models
{
    public class SprintAuxiliar
    {
        public int Id { get; set; }

        [ForeignKey("HistoriaId")]
        public Historia Historia { get; set; }
        public int HistoriaId { get; set; }

        [ForeignKey("SprintId")]
        public Sprint Sprint { get; set; }
        public int SprintId { get; set; }
    }
}
