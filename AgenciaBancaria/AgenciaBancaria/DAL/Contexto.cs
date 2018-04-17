using AgenciaBancaria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgenciaBancaria.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
    }
}