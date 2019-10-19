using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Agendamento
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_pet { get; set; }
        public int id_servico { get; set; }
        public int id_funcionario { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_termino { get; set; }
        public bool notificacao_enviada { get; set; }
        public bool cancelamento { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }


        public string data_inicio_br { get; set; }
        public string data_termino_br { get; set; }


        public Cliente cliente { get; set; }
        public Pet pet { get; set; }
        public Servico servico { get; set; }
        public Funcionario funcionario { get; set; }
    }
}