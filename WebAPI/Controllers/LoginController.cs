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
    public class LoginController : ApiController
    {
        [ActionName("Login")]
        [HttpPost]
        public JsonResult<Usuario> Login(ViewModelLogin vm_login)
        {
            LoginBusiness login = new LoginBusiness();

            return Json(login.FazerLogin(vm_login));
        }

        [ActionName("ValidateLogin")]
        [HttpGet]
        public JsonResult<bool> ValidateLogin()
        {
            return Json(true);
        }
    }
}
