using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace JornalOnline.Controllers
{
    public class ArtigoController : Controller
    {
        private readonly ArtigoDAO _artigoDAO;
        private readonly TemaDAO _temaDAO;
        private readonly PessoaDAO _pessoaDAO;
        private readonly ContratacaoDAO _contratacaoDAO;

        public ArtigoController(ArtigoDAO artigoDAO, TemaDAO temaDAO, PessoaDAO pessoaDAO, ContratacaoDAO contratacaoDAO)
        {
            _artigoDAO = artigoDAO;
            _temaDAO = temaDAO;
            _pessoaDAO = pessoaDAO;
            _contratacaoDAO = contratacaoDAO;
        }

        public IActionResult Index()
        {
            ViewBag.Artigos = _artigoDAO.ListarArtigos();
            return View();
        }

        public IActionResult CadastroArtigo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroArtigo(Pessoa p)
        {

            
            
            return View(p);

        }

        [HttpPost]
        public IActionResult CadastrarArtigo(Pessoa a)
        {
            Artigo artigo = new Artigo();

            artigo.NomeColunista = a.Nome;
            artigo.Paginas = a.ArtigoPaginas;
            artigo.Valor = a.ArtigoValor;
            artigo.Tema = a.ArtigoTema;
            artigo.Texto = a.ArtigoTexto;
            artigo.Titulo = a.ArtigoTitulo;


            //a.ColunistaAutor = _pessoaDAO.BuscarPessoaPorCpf(cpfColunista);
            if (_artigoDAO.CadastrarArtigo(artigo))
            {
                ContratacaoColunista contrata = new ContratacaoColunista();
                contrata.ColunistaAutor = a.Nome;
                contrata.Artigo = artigo;

                if (_contratacaoDAO.SalvarContratacaoColunista(contrata))
                {
                    return RedirectToAction("HomeColunista", "Pessoa");
                }
                else
                {

                    return RedirectToAction("Index", "Home");
                }

                
            }
            else
            {
                ModelState.AddModelError("", "Esse produto já existe!");
                return RedirectToAction("HomeColunista", "Pessoa");
            }

            //return View();
        }

     

        public IActionResult ListarArtigosCadastrados()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult ListarArtigosCadastrados()
        //{
        //    return View();
        //}
    }
}