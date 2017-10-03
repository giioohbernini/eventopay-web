using BlogAM.Models;
using BlogAM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAM.Controllers
{
    public class ClienteController : Controller
    {
        #region Exibe Clietes
        [Authorize]
        [HttpGet]
        public ActionResult Leeds()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = DAO.ClienteDAO.listar();
            return View(clientes);
        }
        #endregion

        #region Psquisa Clientes
        [HttpGet]
        public ActionResult Pesquisar(Cliente cli, bool Receber)
        {
            List<Cliente> clientes = new List<Cliente>();
             
                if (DAO.ClienteDAO.pesquisar(cli, Receber) != null)
                {
                    foreach (var item in DAO.ClienteDAO.pesquisar(cli, Receber))
                    {
                        clientes.Add(item);
                    }
                    return View("Leeds", clientes);
                }
                else
                {
                    return View();
                }
           
        }
        #endregion

        #region tela Cliente
        [HttpGet]
        public ActionResult Cliente()
        {
            ClienteViewModel clienteView = new ClienteViewModel()
            {
                Investimentos = DAO.InvestimentoDAO.listarComCotas(),
                selecao = 3
            };
            return View(clienteView);
        }
        #endregion

        #region Tela Inscrito
        [HttpGet]
        public ActionResult Inscrito()
        {
            return View();
        }
        #endregion

        
        #region Cadastra Cliente
        [HttpPost]
        public ActionResult Cliente(ClienteViewModel clienteView)
        {
            clienteView.InvestimentoAtual = DAO.InvestimentoDAO.pesquisar(clienteView.SelectedItemId);
            if (clienteView.Quantidade > 0 && clienteView.Quantidade<=clienteView.InvestimentoAtual.CotasRestantes)
            {
                clienteView.Cliente.DataCadastro = DateTime.Now;
                clienteView.Cliente.DataNascimento = DateTime.Now;
                clienteView.Cliente.InvestimentoId = clienteView.SelectedItemId;
                DAO.ClienteDAO.cadastrar(clienteView.Cliente, clienteView.Quantidade);
            }
            return RedirectToAction("Index", "Home");
            
        }
        #endregion

        #region Cadastra Inscrito
        [HttpPost]
        public ActionResult Inscrito(Cliente cliente)
        {
            cliente.ReceberNoticiasEmail = true;
            cliente.DataCadastro = DateTime.Now;
            cliente.DataNascimento = DateTime.Now;
            DAO.ClienteDAO.cadastrar(cliente);
            return RedirectToAction("Index", "Home");
        }
        #endregion


        #region Deletar Cliente
        [Authorize]
        [HttpPost]
        public ActionResult Deletar(int tbxId)
        {
            DAO.ClienteDAO.deletar(tbxId);
            return RedirectToAction("Leeds");
        }
        #endregion

        #region Editar Cliente
        [Authorize]
        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {

            DAO.ClienteDAO.editar(cliente.ID, cliente);
            return RedirectToAction("Leeds");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            Cliente cliente = DAO.ClienteDAO.pesquisarPorID(Id);
            return View(cliente);
        }
        #endregion
    }
}