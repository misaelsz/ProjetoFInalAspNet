using AgenciaBancaria.DAL;
using AgenciaBancaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AgenciaBancaria.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Usuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Conta conta, bool chkConectado)
        {
            conta = DAL.ContaDAO.BuscarContaPorNumeroESenha(conta);
            HttpContext.Session["Conta"] = conta;
            if (conta != null)
            {
                //Login
                FormsAuthentication.SetAuthCookie(conta.numeroDaConta, chkConectado);
                return RedirectToAction("Usuario", "Home");
            }
            else
            {
                //Mensagem de erro
                ModelState.AddModelError("", "E-mail ou senha inválidos!");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Contas");
        }
        [HttpPost]
        public ActionResult Depositar(Double valor)
        {
            Conta conta = (Conta)HttpContext.Session["Conta"];
            conta = ContaDAO.BuscaPorId(conta.Id);
            conta.Saldo = conta.Saldo + valor;
            ContaDAO.Editar(conta);
            return RedirectToAction("Usuario", "Home");
        }
        [HttpPost]
        public ActionResult Sacar(Double valor)
        {
            Conta conta = (Conta)HttpContext.Session["Conta"];
            conta = ContaDAO.BuscaPorId(conta.Id);
            if (conta.Saldo > valor) {
                conta.Saldo = conta.Saldo - valor;
                ContaDAO.Editar(conta);
            }
            
            return RedirectToAction("Usuario", "Home");
        }
        [HttpPost]
        public ActionResult Trasferir(Double valor, string ContaDestino, string AgenciaDestino)
        {
          Conta MinhaConta = (Conta)HttpContext.Session["Conta"];
            Conta conta = ContaDAO.BuscarContaPorNumeroEAgencia(ContaDestino, AgenciaDestino);
            if (MinhaConta.Saldo > valor)
            {
                conta.Saldo = conta.Saldo - valor;
                ContaDAO.Editar(conta);
            }
            return View();
        }
    }
}