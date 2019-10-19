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
    public class ServicoController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroServico vm_cadastro_servico)
        {
            ServicoBusiness servico_business = new ServicoBusiness();

            return Json(servico_business.CadastrarServico(vm_cadastro_servico));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Servico>> GetAll()
        {
            ServicoBusiness servico_business = new ServicoBusiness();

            return Json(servico_business.GetAllServicos());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Servico> Get(int servico_id)
        {
            ServicoBusiness servico_business = new ServicoBusiness();

            return Json(servico_business.GetServico(servico_id));
        }

    }
}
