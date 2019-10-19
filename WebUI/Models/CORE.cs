using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUi.Models
{
    public static class CORE
    {

        public static void CreateLoginSession(int usuario)
        {
            System.Web.HttpContext.Current.Session["LOGIN_USUARIO"] = usuario;
        }

        public static bool ValidationLoginSession(int usuario)
        {
            bool retorno = false;

            try
            {
                if (HttpContext.Current.Session["LOGIN_USUARIO"].ToString() != string.Empty
                    && HttpContext.Current.Session["LOGIN_USUARIO"] != null)
                {

                    if (Int32.Parse(HttpContext.Current.Session["LOGIN_USUARIO"].ToString()) == usuario)
                    {
                        retorno = true;
                    }

                }
            }
            catch (Exception ex)
            {
                retorno = false;
            }

            return retorno;
        }

        public static void RemoveLoginSession()
        {
            try
            {
                if (HttpContext.Current.Session["LOGIN_USUARIO"].ToString() != string.Empty
                    && HttpContext.Current.Session["LOGIN_USUARIO"] != null)
                {
                    HttpContext.Current.Session["LOGIN_USUARIO"] = null;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Session["LOGIN_USUARIO"] = null;
            }
        }
    }
}