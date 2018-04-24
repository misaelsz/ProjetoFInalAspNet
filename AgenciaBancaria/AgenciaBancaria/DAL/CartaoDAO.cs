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

       private static Contexto  ctx = Singleton.Instance.Context;

        public static void Cadastrar(Cartao cartao) {
            ctx.Cartoes.Add(cartao);
            ctx.SaveChanges();
        }

        public static List<Cartao> listarTodos() {
            return ctx.Cartoes.ToList();
        }
        public static Cartao BuscaPorId(int? id) {
            return ctx.Cartoes.Find(id);
        }
        public static void Editar(Cartao cartao) {
            ctx.Entry(cartao).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Deletar(Cartao cartao) {
            ctx.Cartoes.Remove(cartao);
            ctx.SaveChanges();

        }
    }
}