using AgilTeamManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AgilTeamManager.Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public EnumNiveisScrum Nivel { get; set; }
        public DateTime DataCadastro { get; set; }
        public byte[] ProfilePicture { get; set; }

    }
}
