using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.ViewModel
{
    public class ClienteViewModel
    {
        public int SelectedItemId { get; set; }
        public int Quantidade { get; set; }
        public Cliente Cliente { get; set; }
        public List<Investimento> Investimentos { get; set; }
        public Investimento InvestimentoAtual { get; set; }
        public List<Cliente> Clientes { get; set; }
        public double TotalInvestido { get; set; }
        public int selecao { get; set; }
    }
}