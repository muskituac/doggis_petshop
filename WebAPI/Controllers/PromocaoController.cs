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
    public class PromocaoController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroPromocao vm_cadastro_promocao)
        {
            PromocaoBusiness promocao_business = new PromocaoBusiness();

            return Json(promocao_business.CadastrarPromocao(vm_cadastro_promocao));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Promocao>> GetAll()
        {
            PromocaoBusiness promocao_business = new PromocaoBusiness();

            return Json(promocao_business.GetAllPromocoes());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Promocao> Get(int promocao_id)
        {
            PromocaoBusiness promocao_business = new PromocaoBusiness();

            return Json(promocao_business.GetPromocao(promocao_id));
        }

    }
}
