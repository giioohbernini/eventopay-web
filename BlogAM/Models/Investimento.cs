using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.Models
{
    public class Investimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public double Beneficio { get; set; }
        public int QtdCotas { get; set; }
        public int CotasRestantes { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}