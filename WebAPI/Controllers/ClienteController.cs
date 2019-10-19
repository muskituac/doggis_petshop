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
    public class ClienteController : ApiController
    {
        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroCliente vm_cadastro_cliente)
        {
            ClienteBusiness cliente_busines = new ClienteBusiness();

            return Json(cliente_busines.CadastrarCliente(vm_cadastro_cliente));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Cliente>> GetAll()
        {
            ClienteBusiness cliente_busines = new ClienteBusiness();

            return Json(cliente_busines.GetAllClientes());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Cliente> Get(int cliente_id)
        {
            ClienteBusiness cliente_busines = new ClienteBusiness();

            return Json(cliente_busines.GetCliente(cliente_id));
        }
    }
}
