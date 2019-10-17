using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class ServicoProduto
    {
        public int id { get; set; }
        public int id_servico { get; set; }
        public int id_produto { get; set; }
        public int quantidade { get; set; }
        public DateTime ultima_alteracao {get;set;}
        public string responsavel { get; set; }
    }
}