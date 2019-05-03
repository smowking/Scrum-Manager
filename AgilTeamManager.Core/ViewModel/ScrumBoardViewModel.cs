using AgilTeamManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.ViewModel
{
    public class ScrumBoardViewModel
    {
        public ScrumBoardViewModel()
        {
            Historias = new List<Historia>();
            ColunasScrum = new List<ScrumBoardColunas>();
            HistoriasDoSprint = new List<Historia>();
            Sprint = new Sprint();
        }

        public List<Historia> HistoriasDoSprint { get; set; }
        public List<Historia> Historias { get; set; }
        public List<ScrumBoardColunas> ColunasScrum { get; set; }
        public Sprint Sprint { get; set; }
    }
}
