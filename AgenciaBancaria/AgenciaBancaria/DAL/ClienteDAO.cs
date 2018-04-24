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

        Contexto ctx = Singleton.Instance.Context;

        public void Cadastrar(Cliente cliente)
        {
            ctx.Clientes.Add(cliente);
            ctx.SaveChanges();
        }

        public List<Cliente> listarTodos()
        {
            return ctx.Clientes.ToList();
        }
        public Cliente BuscaPorId(int? id)
        {
            return ctx.Clientes.Find(id);
        }
        public void Editar(Cliente cliente)
        {
            ctx.Entry(cliente).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Deletar(Cliente cliente)
        {
            ctx.Clientes.Remove(cliente);
            ctx.SaveChanges();

        }

    }
}