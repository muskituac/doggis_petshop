using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class Pet
    {
        public int id { get; set; }
        public int id_pet_tipo { get; set; }
        public int id_cliente { get; set; }
        public string nome { get; set; }
        public string raca { get; set; }
        public string porte { get; set; }
        public string alergias { get; set; }
        public string observacao { get; set; }
        public string autorizacao { get; set; }
        public DateTime ultima_alteracao { get; set; }
        public string responsavel { get; set; }


        public PetTipo pet_tipo { get; set; }
        public Cliente cliente { get; set; }
    }
}