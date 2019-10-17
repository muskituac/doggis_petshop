using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelEntradaEstoque
    {
        public int entrada_estoque_id { get; set; }
        public int entrada_estoque_id_produto { get; set; }
        public int entrada_estoque_quantidade { get; set; }
        public string entrada_estoque_data { get; set; }
        public string entrada_estoque_ultima_alteracao { get; set; }
        public string entrada_estoque_responsavel { get; set; }
    }
}