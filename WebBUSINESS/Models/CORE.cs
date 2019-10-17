using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBASE.ViewModel;

namespace WebBUSINESS.Models
{
    public static class CORE
    {

        public static void CreateLoginSession(ViewModelLogin vm_login)
        {
            System.Web.HttpContext.Current.Session["LOGIN_USUARIO"] = vm_login.LoginUsuario;
            System.Web.HttpContext.Current.Session["LOGIN_SENHA"] = vm_login.LoginSenha;
        }

        public static bool ValidationLoginSession()
        {
            bool retorno = false;

            try
            {
                if (HttpContext.Current.Session["LOGIN_USUARIO"].ToString() != string.Empty
                    && HttpContext.Current.Session["LOGIN_USUARIO"] != null
                    && HttpContext.Current.Session["LOGIN_SENHA"].ToString() != string.Empty
                    && HttpContext.Current.Session["LOGIN_USUARIO"] != null)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}