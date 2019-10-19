using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroPromocao
    {

        public int cadastro_promocao_id { get; set; }
        public string cadastro_promocao_descricao { get; set; }
        public int cadastro_promocao_porcentagem { get; set; }
        public string cadastro_promocao_data_inicio { get; set; }
        public string cadastro_promocao_data_termino { get; set; }
        public string cadastro_promocao_ultima_alteracao { get; set; }
        public string cadastro_promocao_responsavel { get; set; }


        public List<ViewModelCadastroPromocaoProduto> cadastro_promocao_promocao_produto_list { get; set; }
        public List<ViewModelCadastroPromocaoServico> cadastro_promocao_promocao_servico_list { get; set; }

    }
}