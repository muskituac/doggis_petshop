using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebBASE.DTO;
using WebBASE.ViewModel;
using WebBUSINESS.Models;

namespace WebAPI.Controllers
{
    public class VeterinarioController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroVeterinario vm_cadastro_veterinario)
        {
            VeterinarioBusiness veterinario_business = new VeterinarioBusiness();

            return Json(veterinario_business.CadastrarVeterinario(vm_cadastro_veterinario));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Veterinario>> GetAll()
        {
            VeterinarioBusiness veterinario_business = new VeterinarioBusiness();

            return Json(veterinario_business.GetAllVeterinarios());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Veterinario> Get(int veterinario_id)
        {
            VeterinarioBusiness veterinario_business = new VeterinarioBusiness();

            return Json(veterinario_business.GetVeterinario(veterinario_id));
        }

        [ActionName("GetAllVeterinariosByPetTipo")]
        [HttpGet]
        public JsonResult<List<Veterinario>> GetAllVeterinariosByPetTipo(int pet_tipo_id)
        {
            VeterinarioBusiness veterinario_business = new VeterinarioBusiness();

            return Json(veterinario_business.GetAllVeterinariosByPetTipo(pet_tipo_id));
        }

        

    }
}
