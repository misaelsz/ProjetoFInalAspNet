using AgenciaBancaria.Models;
using EcommerceOsorio.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgenciaBancaria.DAL
{
    public class ClienteDAO
    {

       private static Contexto ctx = Singleton.Instance.Context;

        public static void Cadastrar(Cliente cliente)
        {
            ctx.Clientes.Add(cliente);
            ctx.SaveChanges();
        }

        public static List<Cliente> listarTodos()
        {
            return ctx.Clientes.ToList();
        }
        public static Cliente BuscaPorId(int? id)
        {
            return ctx.Clientes.Find(id);
        }
        public static void Editar(Cliente cliente)
        {
            ctx.Entry(cliente).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Deletar(Cliente cliente)
        {
            ctx.Clientes.Remove(cliente);
            ctx.SaveChanges();

        }

    }
}