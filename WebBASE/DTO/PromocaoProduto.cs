using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class PromocaoProduto
    {

        public int id { get; set; }
        public int id_promocao { get; set; }
        public int id_produto { get; set; }


        public Produto produto { get; set; }

    }
}