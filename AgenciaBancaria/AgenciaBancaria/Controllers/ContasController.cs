using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgenciaBancaria.DAL;
using AgenciaBancaria.Models;
using System.Web.Security;

namespace AgenciaBancaria.Controllers
{
    public class ContasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Contas
        public ActionResult Index()
        {
            return View(ContaDAO.listarTodos());
        }

        // GET: Contas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = ContaDAO.BuscaPorId(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // GET: Contas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Agencia,numeroDaConta,Senha,ConfirmacaoSenha")] Conta conta)
        {
            if (ModelState.IsValid)
            {

                conta.DataDeCadastro = DateTime.Now;
                conta.Status = "Ativo";
                conta.Saldo = 0;
                HttpContext.Session["Conta"] = conta;
                return RedirectToAction("Create", "Cliente");
            }

            return View(conta);
        }

        // GET: Contas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = ContaDAO.BuscaPorId(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Agencia,numeroDaConta,Senha,ConfirmacaoSenha,DataDeCadastro,Saldo,DataDeCancelamento,Status")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                ContaDAO.Editar(conta);
                return RedirectToAction("Index");
            }
            return View(conta);
        }

        // GET: Contas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = ContaDAO.BuscaPorId(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                Conta conta = db.Contas.Find(id);
                conta.ConfirmacaoSenha = conta.Senha;
                ContaDAO.Deletar(conta);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["Mensagem"] = "Não é possivel Excluir uma conta com um cliente e cartão vinculados!";
                return View();
            }
            
        }

    }


}
