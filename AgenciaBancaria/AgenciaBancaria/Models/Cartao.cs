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
        [Display(Name = "Número do cartão")]
        public String NumeroDoCartao { get; set; }
        [Display(Name = "Código de segurança")]
        public String CodigoDeSeguranca{ get; set; }
        public String Limite { get; set; }
        public Double Debito { get; set; }
        [Display(Name ="Quantidade de parcelas")]
        public int QUantidadeDeParcelas { get; set; }
        [Display(Name = "Valor da parcela")]
        public Double ValorDaParcela { get; set; }
        public Conta conta { get; set; }
    }
}