using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class PromocaoServico
    {

        public int id { get; set; }
        public int id_promocao { get; set; }
        public int id_servico { get; set; }


        public Servico servico { get; set; }

    }
}