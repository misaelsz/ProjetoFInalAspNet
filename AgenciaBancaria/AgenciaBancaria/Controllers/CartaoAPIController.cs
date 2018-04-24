using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgenciaBancaria.DAL;
using AgenciaBancaria.Models;

namespace AgenciaBancaria.Controllers
{
    public class CartaoAPIController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/CartaoAPI
        public IQueryable<Cartao> GetCartoes()
        {
            return db.Cartoes;
        }

        // GET: api/CartaoAPI/5
        [ResponseType(typeof(Cartao))]
        public IHttpActionResult GetCartao(int id)
        {
            Cartao cartao = db.Cartoes.Find(id);
            if (cartao == null)
            {
                return NotFound();
            }

            return Ok(cartao);
        }

        // PUT: api/CartaoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartao(int id, Cartao cartao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartao.Id)
            {
                return BadRequest();
            }

            db.Entry(cartao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CartaoAPI
        [ResponseType(typeof(Cartao))]
        public IHttpActionResult PostCartao(Cartao cartao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cartoes.Add(cartao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cartao.Id }, cartao);
        }

        // DELETE: api/CartaoAPI/5
        [ResponseType(typeof(Cartao))]
        public IHttpActionResult DeleteCartao(int id)
        {
            Cartao cartao = db.Cartoes.Find(id);
            if (cartao == null)
            {
                return NotFound();
            }

            db.Cartoes.Remove(cartao);
            db.SaveChanges();

            return Ok(cartao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartaoExists(int id)
        {
            return db.Cartoes.Count(e => e.Id == id) > 0;
        }
    }
}