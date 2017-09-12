using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAM.Controllers
{
    
    public class InvestimentoController : Controller
    {
        #region Listar
        [Authorize]
        [HttpGet]
        public ActionResult Index(string NomePesquisa = "")
        {
            List<Investimento> investimento = new List<Investimento>();
            if (NomePesquisa == "")
            {
                investimento = DAO.InvestimentoDAO.listar();
                return View(investimento);
            }
            else
            {
                investimento = DAO.InvestimentoDAO.pesquisar(NomePesquisa);
                return View(investimento);
            }
        }
        #endregion

        #region Cadastrar
        [Authorize]
        [HttpPost]
        public ActionResult Index(Investimento investimento)
        {
            DAO.InvestimentoDAO.cadastrar(investimento);
            return RedirectToAction("Index");
        }
        #endregion

        #region Deletar Noticia
        [Authorize]
        [HttpPost]
        public ActionResult Deletar(int tbxId)
        {
            DAO.InvestimentoDAO.deletar(tbxId);
            return RedirectToAction("Index");
        }
        #endregion

        #region Editar Noticia
        [Authorize]
        [HttpPost]
        public ActionResult Editar(Investimento investimento)
        {
            DAO.InvestimentoDAO.editar(investimento.Id, investimento);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            Investimento investimento = DAO.InvestimentoDAO.pesquisar(Id);
            return View(investimento);
        }
        #endregion

        #region pesquisar
        [Authorize]
        [HttpGet]
        public ActionResult Pesquisar(string NomePesquisa)
        {
            return RedirectToAction("Index", "Investimento", NomePesquisa);
        }
        #endregion
    }
}