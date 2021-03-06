﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgenciaBancaria.DAL;
using AgenciaBancaria.Models;

namespace AgenciaBancaria.Controllers
{
    public class CartoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Cartoes
        public ActionResult Index()
        {
            return View(CartaoDAO.listarTodos());
        }

        // GET: Cartoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = CartaoDAO.BuscaPorId(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // GET: Cartoes/Create
        public ActionResult Create(int id)
        {
            HttpContext.Session["Id"] = id;
            return View();
        }

        // POST: Cartoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroDoCartao,CodigoDeSeguranca,Limite,Debito,QUantidadeDeParcelas,ValorDaParcela")] Cartao cartao)
        {

            int id = (int)HttpContext.Session["id"];

            if (ModelState.IsValid)
            {
                Conta conta = ContaDAO.BuscaPorId(id);
                cartao.conta = conta;
                CartaoDAO.Cadastrar(cartao);
               
                return RedirectToAction("Index");
            }

            return View(cartao);
        }

        // GET: Cartoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = CartaoDAO.BuscaPorId(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // POST: Cartoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroDoCartao,CodigoDeSeguranca,Limite,Debito,QUantidadeDeParcelas,ValorDaParcela")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                CartaoDAO.Editar(cartao);
                return RedirectToAction("Index");
            }
            return View(cartao);
        }

        // GET: Cartoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = CartaoDAO.BuscaPorId(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // POST: Cartoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartaoDAO.Deletar(CartaoDAO.BuscaPorId(id));

            return RedirectToAction("Index");
        }

    }
}
