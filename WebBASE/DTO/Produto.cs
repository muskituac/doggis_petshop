using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string fabricante { get; set; }
        public string especificacoes { get; set; }
        public Decimal valor_atual { get; set; }
        public Decimal pataz_bonus { get; set; }
        public Decimal pataz_custo { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }
    }
}