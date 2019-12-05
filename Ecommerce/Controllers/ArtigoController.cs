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

        public ArtigoController(ArtigoDAO artigoDAO, TemaDAO temaDAO)
        {
            _artigoDAO = artigoDAO;
            _temaDAO = temaDAO;
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
        
        //[HttpPost]
        //public IActionResult CadastrarArtigo(Artigo a, int drpTema)
        //{
        //    ViewBag.Temas = new SelectList
        //        (_temaDAO.ListarTemas(), "IdTema",
        //        "tema");

        //    a.Tema = _temaDAO.BuscarTemaPorId(drpTema);
        //    if (_artigoDAO.CadastrarArtigo(a))
        //    {
        //        return View("HomeColunista", "Pessoa");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError ("", "Esse produto já existe!");
        //        return View(a);
        //    }

        //    //return View();
        //}

        [HttpPost]        
        public IActionResult CadastroArtigo(Artigo a)
        {
           
            if (_artigoDAO.CadastrarArtigo(a))
            {
                return RedirectToAction("HomeColunista", "Pessoa");
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