using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Promocao
    {

        public int id { get; set; }
        public string descricao { get; set; }
        public int porcentagem { get; set; }
        public string data_inicio { get; set; }
        public string data_termino { get; set; }
        public string ultima_alteracao { get; set; }
        public string responsavel { get; set; }


        public List<PromocaoProduto> promocao_produto_list;
        public List<PromocaoServico> promocao_servico_list;


        public Promocao()
        {
            this.promocao_produto_list = new List<PromocaoProduto>();
            this.promocao_servico_list = new List<PromocaoServico>();
        }

    }
}