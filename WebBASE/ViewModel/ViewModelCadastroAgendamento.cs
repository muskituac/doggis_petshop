using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroAgendamento
    {
        public int cadastro_agendamento_id { get; set; }
        public int cadastro_agendamento_id_cliente { get; set; }
        public int cadastro_agendamento_id_pet { get; set; }
        public int cadastro_agendamento_id_servico { get; set; }
        public int cadastro_agendamento_id_funcionario { get; set; }
        public string cadastro_agendamento_data_inicio { get; set; }
        public string cadastro_agendamento_data_termino { get; set; }
        public int cadastro_agendamento_notificacao_enviada { get; set; }
        public int cadastro_agendamento_cancelamento { get; set; }
        public string cadastro_agendamento_ultima_alteracao { get; set; }
        public string cadastro_agendamento_responsavel { get; set; }
    }
}