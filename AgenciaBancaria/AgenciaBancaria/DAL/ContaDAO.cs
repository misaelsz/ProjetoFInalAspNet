using AgenciaBancaria.Models;
using EcommerceOsorio.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgenciaBancaria.DAL
{
    public class ContaDAO
    {
       private static Contexto ctx = Singleton.Instance.Context;

        public static void Cadastrar(Conta conta)
        {
            ctx.Contas.Add(conta);
            ctx.SaveChanges();
        }

        public static List<Conta> listarTodos()
        {
            return ctx.Contas.ToList();
        }
        public static Conta BuscaPorId(int? id)
        {
            return ctx.Contas.Find(id);
        }
        public static void Editar(Conta conta)
        {
            ctx.Entry(conta).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Deletar(Conta conta)
        {
            ctx.Contas.Remove(conta);
            ctx.SaveChanges();

        }

    }
}