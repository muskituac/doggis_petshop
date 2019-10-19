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
    public class AgendamentoController : ApiController
    {

        [ActionName("Cadastrar")]
        [HttpPost]
        public JsonResult<int> Cadastrar(ViewModelCadastroAgendamento vm_cadastro_agendamento)
        {
            AgendamentoBusiness agendamento_business = new AgendamentoBusiness();

            return Json(agendamento_business.CadastrarAgendamento(vm_cadastro_agendamento));
        }

        [ActionName("GetAll")]
        [HttpGet]
        public JsonResult<List<Agendamento>> GetAll()
        {
            AgendamentoBusiness agendamento_business = new AgendamentoBusiness();

            return Json(agendamento_business.GetAllAgendamentoss());
        }

        [ActionName("Get")]
        [HttpGet]
        public JsonResult<Agendamento> Get(int agendamento_id)
        {
            AgendamentoBusiness agendamento_business = new AgendamentoBusiness();

            return Json(agendamento_business.GetAgendamento(agendamento_id));
        }

    }
}
