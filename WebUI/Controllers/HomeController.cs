using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUi.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int usuario_id)
        {
            ViewBag.API_URL = ConfigurationManager.AppSettings["WebAPI_URL"].ToString();
            ViewBag.UsuarioID = usuario_id;

            CORE.CreateLoginSession(usuario_id);
            
            return View();
        }

        public ActionResult IndexAdministrador(int usuario_id)
        {
            ViewBag.API_URL = ConfigurationManager.AppSettings["WebAPI_URL"].ToString();
            ViewBag.UsuarioID = usuario_id;

            if (CORE.ValidationLoginSession(usuario_id))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UsuarioNaoIdentificado", "Error");
            }

        }

        public ActionResult IndexAtendente(int usuario_id)
        {
            ViewBag.API_URL = ConfigurationManager.AppSettings["WebAPI_URL"].ToString();
            ViewBag.UsuarioID = usuario_id;

            if (CORE.ValidationLoginSession(usuario_id))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UsuarioNaoIdentificado", "Error");
            }
        }

        public ActionResult IndexCliente(int usuario_id)
        {
            ViewBag.API_URL = ConfigurationManager.AppSettings["WebAPI_URL"].ToString();
            ViewBag.UsuarioID = usuario_id;

            if (CORE.ValidationLoginSession(usuario_id))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UsuarioNaoIdentificado", "Error");
            }
        }

    }
}