using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroUsuario
    {
        public int cadastro_usuario_id { get; set; }
        public string cadastro_usuario_nome { get; set; }
        public int cadastro_usuario_usuario_tipo { get; set; }
        public string cadastro_usuario_login { get; set; }
        public string cadastro_usuario_senha { get; set; }
        public string cadastro_usuario_ultimo_acesso { get; set; }
        public string cadastro_usuario_ultima_alteracao { get; set; }
        public string cadastro_usuario_responsavel { get; set; }
    }
}