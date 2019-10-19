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
    public class AtendenteController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroAtendente vm_cadastro_atendente)
        {
            AtendenteBusiness atendente_business = new AtendenteBusiness();

            return Json(atendente_business.CadastrarAtendente(vm_cadastro_atendente));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Atendente>> GetAll()
        {
            AtendenteBusiness atendente_business = new AtendenteBusiness();

            return Json(atendente_business.GetAllAtendentes());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Atendente> Get(int atendente_id)
        {
            AtendenteBusiness atendente_business = new AtendenteBusiness();

            return Json(atendente_business.GetAtendente(atendente_id));
        }

    }
}
