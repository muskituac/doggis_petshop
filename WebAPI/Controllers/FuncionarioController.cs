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
    public class FuncionarioController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroFuncionario vm_cadastro_funcionario)
        {
            FuncionarioBusiness funcionario_busines = new FuncionarioBusiness();

            return Json(funcionario_busines.CadastrarFuncionario(vm_cadastro_funcionario));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Funcionario>> GetAll()
        {
            FuncionarioBusiness funcionario_busines = new FuncionarioBusiness();

            return Json(funcionario_busines.GetAllFuncionarios());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Funcionario> Get(int funcionario_id)
        {
            FuncionarioBusiness funcionario_busines = new FuncionarioBusiness();

            return Json(funcionario_busines.GetFuncionario(funcionario_id));
        }

    }
}
