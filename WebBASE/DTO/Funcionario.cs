using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Funcionario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int id_usuario { get; set; }


        public Usuario usuario { get; set; }
    }
}