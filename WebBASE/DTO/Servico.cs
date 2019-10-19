using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Servico
    {
        public int id { get; set; }
        public int tipo_executante { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public Decimal valor_atual { get; set; }
        public int tempo { get; set; }
        public int pataz_bonus { get; set; }
        public int pataz_custo { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }


        public string tipo_executante_descricao {
            get
            {
                return this.tipo_executante == 1 ? "Atendente" : "Veterinario";
            }
        }
        public List<ServicoProduto> servico_produto_list { get; set; }

        public Servico()
        {
            this.servico_produto_list = new List<ServicoProduto>();
        }
    }
}