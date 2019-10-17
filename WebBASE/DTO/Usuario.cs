using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebBASE.DTO
{
    //[Table("usuario", Schema = "doggis_db")]
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int usuario_tipo { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public DateTime ultimo_acesso { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }


        public string usuario_tipo_descricao
        {
            get
            {
                string descricao = "";

                switch (this.usuario_tipo)
                {
                    case 1:
                        descricao = "ADMINISTRADOR";
                        break;
                    case 2:
                        descricao = "ATENDENTE";
                        break;
                    case 3:
                        descricao = "CLIENTE";
                        break;
                }

                return descricao;
            }
        }
    }
}