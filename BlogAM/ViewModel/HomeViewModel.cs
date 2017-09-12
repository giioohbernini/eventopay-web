using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.ViewModel
{
    public class HomeViewModel
    {
        public List<Noticia> noticias { get; set; }
        public List<Investimento> investimentos { get; set; }
    }
}