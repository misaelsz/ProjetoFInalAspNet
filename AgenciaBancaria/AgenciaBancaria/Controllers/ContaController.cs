using AgenciaBancaria.DAL;
using AgenciaBancaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgenciaBancaria.Controllers
{
    [RoutePrefix("api/Conta")]
    public class ContaController : ApiController
    {

        //api/Conta/Todos
        [Route("Todos")]
        public List<Conta> GetTodos()
        {
            return ContaDAO.listarTodos();
        }

        //api/Contas/contaPorId/2
        [Route("ContaPorId/{Id}")]
        public IHttpActionResult GetPorId(int? Id)
        {
            Conta conta = ContaDAO.BuscaPorId(Id);
            if (conta != null)
            {
                return Json(conta);
            }
            else
            {
                return NotFound();
            }
        }

        //api/Contas/ContaDinamica/2
        [Route("ContaDinamica/{Id}")]
        public dynamic GetProdutoDinamico(int? Id)
        {
            Conta conta = ContaDAO.BuscaPorId(Id);
            dynamic produtoDinamico = new
            {
                Agencia = conta.Agencia,
                numeroDaConta = conta.numeroDaConta,
                DataDeCadastro = conta.DataDeCadastro,
            };
            return new { ObjetoProduto = produtoDinamico };
        }

    }
}
