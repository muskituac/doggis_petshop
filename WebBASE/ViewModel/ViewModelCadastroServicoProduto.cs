using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroServicoProduto
    {

        public int cadastro_servico_produto_id { get; set; }
        public int cadastro_servico_produto_id_servico { get; set; }
        public int cadastro_servico_produto_id_produto { get; set; }
        public int cadastro_servico_produto_quantidade { get; set; }
        public string cadastro_servico_produto_ultima_alteracao { get; set; }
        public string cadastro_servico_produto_responsavel { get; set; }

    }
}