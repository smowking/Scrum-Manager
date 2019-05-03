using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilTeamManager.Core.Models;
using AgilTeamManager.Data.Contexto;

namespace AgilTeamManager.Service
{
    public class SprintService
    {
        public static Contexto db = new Contexto();

        public Sprint RetornaUltimoSprint()
        {
            Sprint ultimoSprint = db.Sprints.FirstOrDefault(c => c.DataFim >= DateTime.Today && c.DataInicio <= DateTime.Today);

            return (ultimoSprint != null) ? ultimoSprint : db.Sprints.ToList().LastOrDefault();
        }

    }
}
