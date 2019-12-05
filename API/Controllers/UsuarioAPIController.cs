using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioAPIController : ControllerBase
    {
        private readonly PessoaDAO _pessoaDAO;

        public UsuarioAPIController(PessoaDAO pessoaDAO)
        {
            _pessoaDAO = pessoaDAO;
        }

        //  GET: /api/Pessoa/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_pessoaDAO.ListarPessoas());
        }

    }
}