using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBASE.DTO
{
    public class VeterinarioPetTipo
    {
        public int id { get; set; }
        public int id_veterinario { get; set; }
        public int id_pet_tipo { get; set; }


        public Veterinario veterinario { get; set; }
        public PetTipo pet_tipo { get; set; }
    }
}