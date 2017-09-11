using BlogAM.Context;
using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.DAO
{
    public class ProdutoDAO
    {
        #region Cadastrar
        public static void cadastrar(Produto produto)
        {
            using (var ctx = new ProdutoContext())
            {
                ctx.Produto.Add(produto);
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Deletar
        public static void deletar(int id)
        {
            using (var ctx = new ProdutoContext())
            {
                ctx.Produto.Remove(ctx.Produto.Find(id));
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Listar
        public static List<Produto> listar()
        {
            try
            {
                using (var ctx = new ProdutoContext())
                {
                    return ctx.Produto.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            };
        }
        #endregion



        #region Editar
        public static void editar(int id, Produto produto)
        {
            using (var ctx = new ProdutoContext())
            {
                ctx.Produto.Find(id).Nome = produto.Nome;
                ctx.Produto.Find(id).Descrcao = produto.Descrcao;
                ctx.Produto.Find(id).Imagem = produto.Imagem;
                ctx.Produto.Find(id).Valor = produto.Valor;
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Pesquisar por Id
        public static Produto pesquisar(int id)
        {
            using (var ctx = new ProdutoContext())
            {
                return ctx.Produto.Find(id);
            }
        }
        #endregion

        #region Pesquisar por Nome
        public static List<Produto> pesquisar(string Nome)
        {
            using (var ctx = new ProdutoContext())
            {
                return ctx.Produto.Where(t => t.Nome.Contains(Nome)).ToList();
            }
        }
        #endregion
    }
}