using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilTeamManager.Core.Models;

namespace AgilTeamManager.Core.ViewModel
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Eventos = new List<Evento>();
            DiasSprint = new List<DateTime>();
        }

        public List<DateTime> DiasSprint;
        public List<Evento> Eventos;
        public Sprint Sprint { get; set; }
    }
}
