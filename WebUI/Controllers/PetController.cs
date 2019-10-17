using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUi.Models;

namespace WebUI.Controllers
{
    public class PetController : Controller
    {
        public ActionResult Cadastro(int usuario_id)
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

        public ActionResult Lista(int usuario_id)
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