using AgilTeamManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AgilTeamManager.Core.Models
{
    public class Historia
    {
        public int Id { get; set; }
        public string Numero
        {
            get {
                return Id.ToString() + "/" + DataAbertura.Year.ToString();
            }
        }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataTermino { get; set; }

        [ForeignKey("RecursoId")]
        public Recurso Recurso { get; set; }
        public int? RecursoId { get; set; }

        [ForeignKey("ScrumBoardColunasId")]
        public ScrumBoardColunas ScrumBoardColunas { get; set; }
        public int? ScrumBoardColunasId { get; set; }

        [DefaultValue("")]
        public string Observacao { get; set; }

        /// <summary>
        /// Id do desenvolvedor responsável pela história
        /// </summary>
        public int? IdDesenvolvedorResponsavel { get; set; }

        /// <summary>
        /// Criador da história
        /// </summary>
        public int IdCriadorResponsavel { get; set; }

        /// <summary>
        /// Projeto referente à história
        /// </summary>
        public int IdProjeto { get; set; }

        [NotMapped]
        public string DataAberturaEncurtado { get { return DataAbertura.ToShortDateString(); } }

        public string FotoDesenvolvedor { get; set; }
    }
}
