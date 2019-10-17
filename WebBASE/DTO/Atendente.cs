using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Atendente
    {
        public int id { get; set; }
        public int id_funcionario { get; set; }
        public string nome { get; set; }


        public Funcionario funcionario { get; set; }
    }
}