using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroServico
    {
        public int cadastro_servico_id { get; set; }
        public int cadastro_servico_tipo_executante { get; set; }
        public string cadastro_servico_nome { get; set; }
        public string cadastro_servico_descricao { get; set; }
        public Decimal cadastro_servico_valor_atual { get; set; }
        public int cadastro_servico_tempo { get; set; }
        public int cadastro_servico_pataz_bonus { get; set; }
        public int cadastro_servico_pataz_custo { get; set; }
        public string cadastro_servico_ultima_alteracao { get; set; }
        public string cadastro_servico_responsavel { get; set; }


        public List<ViewModelCadastroServicoProduto> cadastro_servico_produto_list { get; set; }

    }
}