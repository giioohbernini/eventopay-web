using BlogAM.Context;
using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAM.DAO
{
    public class ClienteDAO
    {
        #region Cadastrar Inscrito
        public static void cadastrar(Cliente cliente)
        {
            using (var ctx = new ClienteContext())
            {
                ctx.Cliente.Add(cliente);
                ctx.SaveChanges();
            }
        }
        #endregion
        #region Cadastrar Cliente
        public static void cadastrar(Cliente cliente,int qtdCota)
        {
            Investimento investimento = DAO.InvestimentoDAO.pesquisar(Int32.Parse(cliente.InvestimentoId.ToString()));
            if (qtdCota<=0)
            {
                qtdCota = 1;
            }
            cliente.Valor = investimento.Valor*qtdCota;
            cliente.Beneficio = investimento.Beneficio * qtdCota;
            using (var ctx = new ClienteContext())
            {
                ctx.Cliente.Add(cliente);
                ctx.SaveChanges();
            }
            investimento.CotasRestantes -= qtdCota;
            InvestimentoDAO.editar(investimento.Id,investimento);
        }
        #endregion

        #region Listar
        public static List<Cliente> listar()
        {
            try
            {
                using (var ctx = new ClienteContext())
                {
                    return ctx.Cliente.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            };
        }
        #endregion

        #region Pesquisar 
        public static List<Cliente> pesquisar(Cliente cli, bool Receber)
        {
            cli.Nome = cli.Nome == null ? "" : cli.Nome;
            cli.Email = cli.Email == null ? "" : cli.Email;
            cli.Cidade = cli.Cidade == null ? "" : cli.Cidade;
            string CPF = cli.CPF.ToString();
            CPF = CPF == null ? "" : CPF;
            
            using (var ctx = new ClienteContext())
            {
                if (Receber)
                {
                    //if (CPF!="")
                    //{
                        return ctx.Cliente.Where((t => t.Nome.Contains(cli.Nome) && t.Email.Contains(cli.Email) && t.Cidade.Contains(cli.Cidade) && t.ReceberNoticiasEmail == cli.ReceberNoticiasEmail && t.CPF.ToString().Contains(CPF))).ToList();
                    //}
                    //else
                    //{
                    //    return ctx.Cliente.Where((t => t.Nome.Contains(cli.Nome) && t.Email.Contains(cli.Email) && t.Cidade.Contains(cli.Cidade) && t.ReceberNoticiasEmail == cli.ReceberNoticiasEmail )).ToList();
                    //}
                }
                else
                {
                    //if (CPF != "")
                    //{
                        return ctx.Cliente.Where((t => t.Nome.Contains(cli.Nome) && t.Email.Contains(cli.Email) && t.Cidade.Contains(cli.Cidade)  && t.CPF.ToString().Contains(CPF))).ToList();
                    //}
                    //else
                    //{
                    //    return ctx.Cliente.Where((t => t.Nome.Contains(cli.Nome) && t.Email.Contains(cli.Email) && t.Cidade.Contains(cli.Cidade) )).ToList();
                    //}
                }
            }
        }
        public static List<Cliente> pesquisarAmbos(Cliente cli)
        {
            cli.Nome = cli.Nome == null ? "" : cli.Nome;
            cli.Email = cli.Email == null ? "" : cli.Email;
            cli.Cidade = cli.Cidade == null ? "" : cli.Cidade;
            string CPF = cli.CPF.ToString();
            CPF = CPF == null ? "" : CPF;
            using (var ctx = new ClienteContext())
            {
                return ctx.Cliente.Where((t => t.Nome.Contains(cli.Nome) && t.Email.Contains(cli.Email) && t.Cidade.Contains(cli.Cidade) && t.CPF.ToString().Contains(CPF))).ToList();
            }
        }
        #endregion

        #region Editar
        public static void editar(int id, Cliente cliente)
        {
            using (var ctx = new ClienteContext())
            {
                ctx.Cliente.Find(id).Nome = cliente.Nome;
                ctx.Cliente.Find(id).Email = cliente.Email;
                ctx.Cliente.Find(id).Cidade = cliente.Cidade;
                ctx.Cliente.Find(id).CPF = cliente.CPF;
                ctx.Cliente.Find(id).numeroCartao = cliente.numeroCartao;
                ctx.Cliente.Find(id).ReceberNoticiasEmail = cliente.ReceberNoticiasEmail;
                ctx.SaveChanges();
            }
        }
        #endregion

        #region Deletar
        public static void deletar(int id)
        {
            using (var ctx = new ClienteContext())
            {
                ctx.Cliente.Remove(ctx.Cliente.Find(id));
                ctx.SaveChanges(); 
            }
        }
        #endregion

        #region Pesquisar pelo ID
        public static Cliente pesquisarPorID(int id)
        {
            using (var ctx = new ClienteContext())
            {
                return ctx.Cliente.Find(id);
            }
        }
        #endregion
        
        #region Pesquisar pelo ID
        public static double GetTotalInvestido()
        {
            using (var ctx = new ClienteContext())
            {
                return ctx.Cliente.Sum(a => a.Valor);
            }
        }
#endregion


    }
}
