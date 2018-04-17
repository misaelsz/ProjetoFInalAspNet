using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgenciaBancaria.Models
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public String Agencia { get; set; }
        public String numeroDaConta { get; set; }
        public DateTime DataDeCadastro{ get; set; }
        public Double Saldo { get; set; }
        public String DataDeCancelamento { get; set; }
        public String Status { get; set; }//Status da conta é a situação da conta exemplo Status = cancelada ou Status = Ativa
        public List<Cartao> listaDeCartoes{ get; set; }
    }
}