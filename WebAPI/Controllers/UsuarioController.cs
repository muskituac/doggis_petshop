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
    public class UsuarioController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroUsuario vm_cadastro_usuario)
        {
            UsuarioBusiness usuario_busines = new UsuarioBusiness();

            return Json(usuario_busines.CadastrarUsuario(vm_cadastro_usuario));
        }

        [ActionName("GetUsuario")]
        [HttpGet]
        public JsonResult<Usuario> GetUsuario(int usuario_id)
        {
            UsuarioBusiness usuario_business = new UsuarioBusiness();

            return Json(usuario_business.GetUsuario(usuario_id));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Usuario>> GetAll()
        {
            UsuarioBusiness usuario_business = new UsuarioBusiness();

            return Json(usuario_business.GetAllUsuarios());
        }

        [ActionName("GetAllDetalhados")]
        [HttpGet]
        public JsonResult<List<Usuario>> GetAllDetalhados()
        {
            UsuarioBusiness usuario_business = new UsuarioBusiness();

            return Json(usuario_business.GetAllUsuariosDetalhados());
        }
    }
}
