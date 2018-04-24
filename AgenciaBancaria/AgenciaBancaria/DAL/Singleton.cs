using AgenciaBancaria.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceOsorio.DAL
{
    class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private readonly Contexto context;

        private Singleton()
        {
            context = new Contexto();
        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public Contexto Context
        {
            get
            {
                return context;
            }
        }
    }
}