using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.Models
{
    public class ScrumBoardColunas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ordem { get; set; }

        [ForeignKey("ScrumBoardColunasId")]
        public ICollection<Historia> Historias { get; set; }
    }
}
