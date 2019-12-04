using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace JornalOnline.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;

        public ProdutoController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        public IActionResult Index()
        {
            ViewBag.Produtos = _produtoDAO.ListarProdutos();
            ViewBag.DataHora = DateTime.Now;

            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost] // Informa que a Action só ira ser acessada se for via POST
        public IActionResult Cadastrar(Produto p)
        {
            //ModelState serve para confirmar que as anotações criadas no Modelo Produto, estão sendo atendidas.
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Cadastrar(p))
                {
                    return RedirectToAction("Index");

                }
                //enviar mensagem para a tela
                ModelState.AddModelError("", "Um produto já foi cadastrado com este Nome");
                return View(p);
            }
            return View(p);
            
        }

        public IActionResult Remover(int? id)
        {
            if (id != null)
            {
                _produtoDAO.RemoverProduto(_produtoDAO.BuscarProdutoPorId(id));
                return RedirectToAction("Index");
            }
            else
            {
                //redirecionar para uma página de erro.
            }

            return RedirectToAction("Index");
        }

        public IActionResult Alterar (int? id)
        {
            ViewBag.Produto = _produtoDAO.BuscarProdutoPorId(id);

            return View();
        }


        public IActionResult AlterarObjetoDb(string txtNome, string txtDescricao, string txtPreco, string txtQuantidade, string hdnId)
        {
           

            Produto p = _produtoDAO.BuscarProdutoPorId(Convert.ToInt32(hdnId));
            p.Nome = txtNome;
            p.Descricao = txtDescricao;
            p.Preco = Convert.ToDouble(txtPreco);
            p.Quantidade = Convert.ToInt32(txtQuantidade);
           

            _produtoDAO.AlterarProduto(p);
            return RedirectToAction("Index");
        }
    }
}