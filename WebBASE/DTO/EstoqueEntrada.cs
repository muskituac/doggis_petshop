
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class EstoqueEntrada
    {
        public int id { get; set; }
        public int produto_id { get; set; }
        public int quantidade { get; set; }
        public DateTime data { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }

        public Produto produto { get; set; }
    }
}