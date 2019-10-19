using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.ViewModel
{
    public class ViewModelCadastroVeterinario
    {
        public int cadastro_veterinario_id { get; set; }
        public int cadastro_veterinario_id_funcionario { get; set; }
        public string cadastro_veterinario_nome { get; set; }
        public string cadastro_veterinario_cpf { get; set; }
        public string cadastro_veterinario_identidade { get; set; }
        public string cadastro_veterinario_registro { get; set; }
        public string cadastro_veterinario_ultima_alteracao { get; set; }
        public string cadastro_veterinario_responsavel { get; set; }


        public List<ViewModelCadastroVeterinarioPetTipo> cadastro_veterinario_pet_tipo_list { get; set; }
    }
}