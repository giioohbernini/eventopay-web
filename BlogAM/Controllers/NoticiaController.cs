using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAM.Controllers
{
    public class NoticiaController : Controller
    {
        #region Cadastrar e pesquisar noticias
        [Authorize]
        [HttpGet]
        public ActionResult Index(string autorPesquisa = "")
        {
            List<Noticia> noticias = new List<Noticia>();
            if (autorPesquisa == "")
            {

                noticias = DAO.NoticiaDAO.listar();
                return View(noticias);
            }
            else
            {

                if (DAO.NoticiaDAO.pesquisar(autorPesquisa) != null)
                {
                    foreach (var item in DAO.NoticiaDAO.pesquisar(autorPesquisa))
                    {
                        noticias.Add(item);
                    }
                    return View("Index", noticias);
                }
                else
                {
                    noticias = DAO.NoticiaDAO.listar();
                    return View(noticias);
                }
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(string tbxTitulo, string tbxMensagem, string tbxAutor)
        {
            Noticia noticia = new Noticia()
            {
                Titulo = tbxTitulo,
                Autor = tbxAutor,
                Mensagem = tbxMensagem,
                Data = DateTime.Now
            };
            DAO.NoticiaDAO.cadastrar(noticia);
            return RedirectToAction("Index");
        }
        #endregion

        #region Deletar Noticia
        [Authorize]
        [HttpPost]
        public ActionResult Deletar(int tbxId)
        {
            DAO.NoticiaDAO.deletar(tbxId);
            return RedirectToAction("Index");
        }
        #endregion

        #region Editar Noticia
        [Authorize]
        [HttpPost]
        public ActionResult Editar(Noticia noticias)
        {

            DAO.NoticiaDAO.editar(noticias.Id, noticias);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            Noticia noticia = DAO.NoticiaDAO.pesquisar(Id);
            return View(noticia);
        }
        #endregion

        #region Noticias
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Noticias()
        {
            List<Noticia> noticias = new List<Noticia>();
            noticias = DAO.NoticiaDAO.listar();
            return View(noticias);
        }
        #endregion
    }
}