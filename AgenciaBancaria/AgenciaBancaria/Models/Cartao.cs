using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgenciaBancaria.Models
{
    [Table("Cartoes")]
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        public String NumeroDoCartao { get; set; }
        public String CodigoDeSeguranca{ get; set; }
        public String Limite { get; set; }
        public Double Debito { get; set; }
        public int QUantidadeDeParcelas { get; set; }
        public Double ValorDaParcela { get; set; }

    }
}