using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Tema")]
    [ApiController]
    public class TemaAPIController : ControllerBase
    {
        private readonly TemaDAO _temaDAO;

        public TemaAPIController(TemaDAO temaDAO)
        {
            _temaDAO = temaDAO;
        }

        //ListarTodosOsTemas
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_temaDAO.ListarTemas());
        }
    }
}