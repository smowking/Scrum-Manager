using AgilTeamManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.ViewModel
{
    public class SprintViewModel
    {
        public SprintViewModel()
        {
            Sprint = new Sprint();
            ScrumBoardViewModel = new ScrumBoardViewModel();
        }

        public Sprint Sprint { get; set; }
        public ScrumBoardViewModel ScrumBoardViewModel { get; set; }
    }
}
