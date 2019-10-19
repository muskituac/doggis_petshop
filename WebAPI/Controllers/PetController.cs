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
    public class PetController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroPet vm_cadastro_pet)
        {
            PetBusiness pet_busines = new PetBusiness();

            return Json(pet_busines.CadastrarPet(vm_cadastro_pet));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Pet>> GetAll()
        {
            PetBusiness pet_busines = new PetBusiness();

            return Json(pet_busines.GetAllPets());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Pet> Get(int pet_id)
        {
            PetBusiness pet_busines = new PetBusiness();

            return Json(pet_busines.GetPet(pet_id));
        }

        [ActionName("GetPetByCliente")]
        [HttpGet]
        public JsonResult<List<Pet>> GetPetByCliente(int cliente_id)
        {
            PetBusiness pet_busines = new PetBusiness();

            return Json(pet_busines.GetPetByCliente(cliente_id));
        }

    }
}
