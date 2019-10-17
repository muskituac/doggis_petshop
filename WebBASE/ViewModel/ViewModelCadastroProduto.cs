using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroProduto
    {
        public int? cadastro_produto_id { get; set; }
        public string cadastro_produto_nome { get; set; }
        public string cadastro_produto_fabricante { get; set; }
        public string cadastro_produto_especificacoes { get; set; }
        public Decimal cadastro_produto_valor_atual { get; set; }
        public Decimal cadastro_produto_pataz_bonus { get; set; }
        public Decimal cadastro_produto_pataz_custo { get; set; }
        public string cadastro_produto_ultima_alteracao { get; set; }
        public string cadastro_produto_responsavel { get; set; }
    }
}