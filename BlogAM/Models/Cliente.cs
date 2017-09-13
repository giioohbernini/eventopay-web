using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogAM.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CPF { get; set; }
        public bool ReceberNoticiasEmail { get; set; }
        public int numeroCartao { get; set; }
        public double Valor { get; set; }
        public double Beneficio { get; set; }

        public int? InvestimentoId { get; set; }
        [ForeignKey("InvestimentoId")]
        public Investimento investimento { get; set; }
    }
}