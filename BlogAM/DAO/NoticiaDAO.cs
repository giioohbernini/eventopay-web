using BlogAM.Context;
using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.DAO
{
    public class NoticiaDAO
    {
       
        #region Cadastrar
        public static void cadastrar(Noticia noticia)
        {
            using (var ctx = new NoticiaContext())
            {
                ctx.Noticia.Add(noticia);
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Deletar
        public static void deletar(int id)
        {
            using (var ctx = new NoticiaContext())
            {
                ctx.Noticia.Remove(ctx.Noticia.Find(id));
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Listar
        public static List<Noticia> listar()
        {
            try
            {
                using (var ctx = new NoticiaContext())
                {
                    return ctx.Noticia.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            };
        }
        #endregion



        #region Editar
        public static void editar(int id, Noticia noticia)
        {
            using (var ctx = new NoticiaContext())
            {
                ctx.Noticia.Find(id).Autor = noticia.Autor;
                ctx.Noticia.Find(id).Mensagem = noticia.Mensagem;
                ctx.Noticia.Find(id).Titulo = noticia.Titulo;
                ctx.Noticia.Find(id).Data = DateTime.Now;
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Pesquisar por Id
        public static Noticia pesquisar(int id)
        {
            using (var ctx = new NoticiaContext())
            {
                return ctx.Noticia.Find(id);
            }
        }
        #endregion

        #region Pesquisar por Nome
        public static List<Noticia> pesquisar(string Autor)
        {
            using (var ctx = new NoticiaContext())
            {
                return ctx.Noticia.Where(t => t.Autor.Contains(Autor)).ToList();
            }
        }
        #endregion


        #region Pesquisar por tudo
        public static List<Noticia> pesquisarTudo(string pesquisa)
        {
            using (var ctx = new NoticiaContext())
            {
                return ctx.Noticia.Where(t => t.Autor.Contains(pesquisa)||t.Titulo.Contains(pesquisa)||t.Mensagem.Contains(pesquisa)).ToList();
            }
        }
        #endregion
    }
}