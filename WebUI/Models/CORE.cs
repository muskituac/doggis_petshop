using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public static class CORE
    {
        public static bool ValidationLoginSession(HttpContextBase context)
        {
            bool retorno = false;

            try
            {
                if (context.Session["LOGIN_USUARIO"].ToString() != string.Empty
                    && context.Session["LOGIN_USUARIO"] != null
                    && context.Session["LOGIN_SENHA"].ToString() != string.Empty
                    && context.Session["LOGIN_USUARIO"] != null)
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