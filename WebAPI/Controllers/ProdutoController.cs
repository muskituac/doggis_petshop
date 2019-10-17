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
    public class ProdutoController : ApiController
    {
        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<bool> Cadastrar(ViewModelCadastroProduto vm_cadastro_produto)
        {
            ProdutoBusiness produto_busines = new ProdutoBusiness();

            return Json(produto_busines.CadastrarProduto(vm_cadastro_produto));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Produto>> GetAll()
        {
            ProdutoBusiness produto_busines = new ProdutoBusiness();

            return Json(produto_busines.GetAllProdutos());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Produto> Get(int produto_id)
        {
            ProdutoBusiness produto_busines = new ProdutoBusiness();

            return Json(produto_busines.GetProduto(produto_id));
        }
    }
}
