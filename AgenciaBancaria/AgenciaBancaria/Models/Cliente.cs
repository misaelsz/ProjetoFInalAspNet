using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgenciaBancaria.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome do correntista")]
        public String Nome { get; set; }
        public String Telefone { get; set; }
        [Display(Name = "CEP")]
        public String code { get; set; }
        public int status { get; set; }
        [Display(Name = "Estado")]
        public string state { get; set; }
        [Display(Name = "Cidade")]
        public string city { get; set; }
        [Display(Name = "Bairro")]
        public string district { get; set; }
        [Display(Name = "Endereço")]
        public string address { get; set; }

        public Conta conta{ get; set; }
    }
}