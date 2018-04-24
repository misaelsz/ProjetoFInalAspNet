using AgenciaBancaria.Models;
using EcommerceOsorio.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgenciaBancaria.DAL
{
    public class CartaoDAO
    {

        Contexto ctx = Singleton.Instance.Context;

        public void Cadastrar(Cartao cartao) {
            ctx.Cartoes.Add(cartao);
            ctx.SaveChanges();
        }

        public List<Cartao> listarTodos() {
            return ctx.Cartoes.ToList();
        }
        public Cartao BuscaPorId(int? id) {
            return ctx.Cartoes.Find(id);
        }
        public void Editar(Cartao cartao) {
            ctx.Entry(cartao).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Deletar(Cartao cartao) {
            ctx.Cartoes.Remove(cartao);
            ctx.SaveChanges();

        }
    }
}