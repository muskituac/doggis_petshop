using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebBASE.DTO;
using WebBUSINESS.Models;

namespace WebAPI.Controllers
{
    public class PetTipoController : ApiController
    {

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<PetTipo>> GetAll()
        {
            PetTipoBusiness pet_tipo_busines = new PetTipoBusiness();

            return Json(pet_tipo_busines.GetAllPetTipos());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<PetTipo> Get(int pet_id)
        {
            PetTipoBusiness pet_tipo_busines = new PetTipoBusiness();

            return Json(pet_tipo_busines.GetPetTipo(pet_id));
        }

    }
}
