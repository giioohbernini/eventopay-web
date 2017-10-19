using BlogAM.Context;
using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.DAO
{
    public class InvestimentoDAO
    {

        #region Cadastrar
        public static void cadastrar(Investimento investimento)
        {
            using (var ctx = new InvestimentoContext())
            {
                investimento.CotasRestantes = investimento.QtdCotas;
                ctx.Investimento.Add(investimento);
                
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Deletar
        public static void deletar(int id)
        {
            using (var ctx = new InvestimentoContext())
            {
                ctx.Investimento.Remove(ctx.Investimento.Find(id));
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Listar Todos
        public static List<Investimento> listar()
        {
            try
            {
                using (var ctx = new InvestimentoContext())
                {
                    return ctx.Investimento.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            };
        }
        #endregion

        #region Listar com Cotas
        public static List<Investimento> listarComCotas()
        {
            try
            {
                using (var ctx = new InvestimentoContext())
                {
                    return ctx.Investimento.Where(a=>a.CotasRestantes>0).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            };
        }
        #endregion

        #region Editar
        public static void editar(int id, Investimento investimento)
        {
            using (var ctx = new InvestimentoContext())
            {
                ctx.Investimento.Find(id).Nome = investimento.Nome;
                ctx.Investimento.Find(id).Descricao= investimento.Descricao;
                ctx.Investimento.Find(id).Valor= investimento.Valor;
                ctx.Investimento.Find(id).Beneficio = investimento.Beneficio;
                ctx.Investimento.Find(id).QtdCotas = investimento.QtdCotas;
                //ctx.Investimento.Find(id).CotasRestantes = investimento.CotasRestantes;
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Pesquisar por Id
        public static Investimento pesquisar(int id)
        {
            using (var ctx = new InvestimentoContext())
            {
                return ctx.Investimento.Find(id);
            }
        }
        #endregion

        #region Pesquisar por Nome
        public static List<Investimento> pesquisar(string nome)
        {
            using (var ctx = new InvestimentoContext())
            {
                return ctx.Investimento.Where(t => t.Nome.Contains(nome)).ToList();
            }
        }
        #endregion


    }
}