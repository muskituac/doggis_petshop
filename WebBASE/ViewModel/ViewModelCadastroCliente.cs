using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroCliente
    {
        public int cadastro_cliente_id { get; set; }
        public string cadastro_cliente_nome { get; set; }
        public string cadastro_cliente_identidade { get; set; }
        public string cadastro_cliente_cpf { get; set; }
        public string cadastro_cliente_endereco { get; set; }
        public string cadastro_cliente_email { get; set; }
        public string cadastro_cliente_autorizacao { get; set; }
        public string cadastro_cliente_ultima_alteracao { get; set; }
        public string cadastro_cliente_responsavel { get; set; }
    }
}