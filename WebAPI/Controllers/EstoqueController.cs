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
    public class EstoqueController : ApiController
    {
        [ActionName("Entrada")]
        [HttpPost]
        public JsonResult<bool> Entrada(ViewModelEntradaEstoque vm_entrada_estoque)
        {
            EstoqueBusiness estoque_busines = new EstoqueBusiness();

            return Json(estoque_busines.Entrada(vm_entrada_estoque));
        }

        [ActionName("GetAllEntradas")]
        [HttpGet]
        public JsonResult<List<EstoqueEntrada>> GetAllEntradas()
        {
            EstoqueBusiness estoque_busines = new EstoqueBusiness();

            return Json(estoque_busines.GetAllEntradas());
        }
    }
}
