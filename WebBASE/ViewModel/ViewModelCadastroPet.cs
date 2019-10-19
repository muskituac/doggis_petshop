using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroPet
    {

        public int cadastro_pet_id { get; set; }
        public int cadastro_pet_id_pet_tipo { get; set; }
        public int cadastro_pet_id_cliente { get; set; }
        public string cadastro_pet_nome { get; set; }
        public string cadastro_pet_raca { get; set; }
        public string cadastro_pet_porte { get; set; }
        public string cadastro_pet_alergias { get; set; }
        public string cadastro_pet_observacao { get; set; }
        public string cadastro_pet_autorizacao { get; set; }
        public string cadastro_pet_ultima_alteracao { get; set; }
        public string cadastro_pet_responsavel { get; set; }

    }
}