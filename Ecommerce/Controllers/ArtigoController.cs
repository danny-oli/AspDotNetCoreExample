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

        public ArtigoController(ArtigoDAO artigoDAO, TemaDAO temaDAO, PessoaDAO pessoaDAO)
        {
            _artigoDAO = artigoDAO;
            _temaDAO = temaDAO;
            _pessoaDAO = pessoaDAO;
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

            
            ViewBag.ColunistaID = p.PessoaId;
            return View();

        }

        [HttpPost]
        public IActionResult CadastrarArtigo(Artigo a)
        {


            //a.ColunistaAutor = _pessoaDAO.BuscarPessoaPorCpf(cpfColunista);
            if (_artigoDAO.CadastrarArtigo(a))
            {
                return View("HomeColunista", "Pessoa");
            }
            else
            {
                ModelState.AddModelError("", "Esse produto já existe!");
                return View(a);
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