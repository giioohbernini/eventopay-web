using System;
using System.Collections.Generic;
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
    }
}