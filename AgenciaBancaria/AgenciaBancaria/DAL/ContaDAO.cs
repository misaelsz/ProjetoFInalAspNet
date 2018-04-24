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
            using (var context = Singleton.Instance.Context)
            {
                context.Entry(conta).State = EntityState.Modified;
                context.SaveChanges();

            }
            
        }

        public static void Deletar(Conta conta)
        {
            ctx.Contas.Remove(conta);
            ctx.SaveChanges();

        }

        public static Conta BuscarContaPorNumeroESenha(Conta conta) {
            return ctx.Contas.FirstOrDefault(x =>
                x.numeroDaConta.Equals(conta.numeroDaConta) &&
                x.Senha.Equals(conta.Senha));
        }

        public static Conta BuscarContaPorNumeroEAgencia(string num, string ag)
        {
            return ctx.Contas.FirstOrDefault(x =>
                x.numeroDaConta.Equals(num) &&
                x.Agencia.Equals(ag));
        }

    }
}