using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Veterinario
    {
        public int id { get; set; }
        public int id_funcionario { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string identidade { get; set; }
        public string registro { get; set; } 
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }


        public Funcionario funcionario { get; set; }

        public List<VeterinarioPetTipo> veterinario_pet_tipo_list { get; set; }

        public Veterinario()
        {
            this.veterinario_pet_tipo_list = new List<VeterinarioPetTipo>();
        }
    }
}