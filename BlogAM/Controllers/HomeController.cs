using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAM.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Noticia> noticias = new List<Noticia>();
            noticias = DAO.NoticiaDAO.listar();
            return View(noticias);
        }
    }
}