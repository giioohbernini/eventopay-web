using BlogAM.Models;
using BlogAM.ViewModel;
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
            HomeViewModel model = new HomeViewModel()
            {
                noticias = DAO.NoticiaDAO.listar(),
                investimentos = DAO.InvestimentoDAO.listar()
            };
            return View(model);
        }
    }
}