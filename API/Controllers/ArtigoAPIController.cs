using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Artigo")]
    [ApiController]
    public class ArtigoAPIController : ControllerBase
    {
        private readonly ArtigoDAO _artigoDAO;

        public ArtigoAPIController(ArtigoDAO artigoDAO)
        {
            _artigoDAO = artigoDAO;
        }

        //ListarTodosOsArtigos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_artigoDAO.ListarArtigos());
        }
    }
}