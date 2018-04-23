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
using System.Text;
using Newtonsoft.Json;

namespace AgenciaBancaria.Controllers
{
    public class ClienteController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            Cliente cliente = (Cliente)HttpContext.Session["Usuario"];
            return View(cliente);
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,code,state,city,district,address")] Cliente cliente)
        {
            
            
            
            cliente = (Cliente)HttpContext.Session["Usuario"];
            cliente.conta = (Conta)HttpContext.Session["Conta"];
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Include("Conta").FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,code,state,city,district,address,Conta")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PesquisarCep(Cliente cliente)
        {
            string url = "http://apps.widenet.com.br/busca-cep/api/cep/" + cliente.code + ".json/";
            WebClient client = new WebClient();
            try
            {
                Cliente clienteAux = cliente;
                //Consumindo os dados do Viacep
                string resultado = client.DownloadString(@url);
                //Converter para UTF8
                byte[] bytes = Encoding.Default.GetBytes(resultado);
                resultado = Encoding.UTF8.GetString(bytes);
                //Converter os dados da string em objeto
                cliente = JsonConvert.DeserializeObject<Cliente>(resultado);

                
                cliente.Nome = clienteAux.Nome;
                cliente.Telefone = clienteAux.Telefone;

                //Passar o objeto preenchido para outra Action
                HttpContext.Session["Usuario"] = cliente;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP inválido!";
            }
            return RedirectToAction("Create", "Cliente");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
