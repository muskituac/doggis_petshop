using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class PetTipo
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }
    }
}