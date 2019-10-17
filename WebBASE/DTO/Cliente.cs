using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string identidade { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public string autorizacao { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }


        public List<Pet> PetList { get; set; }

        public Cliente()
        {
            this.PetList = new List<Pet>();
        }

    }
}