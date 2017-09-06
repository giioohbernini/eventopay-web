using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
        public string Autor { get; set; }
    }
}
