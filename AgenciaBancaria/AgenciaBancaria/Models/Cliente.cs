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
        public String CEP{ get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

        [Display(Name = "Senha do usuário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação de senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }

        public Conta conta{ get; set; }
    }
}