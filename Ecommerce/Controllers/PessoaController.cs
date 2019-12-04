using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace JornalOnline.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaDAO _pessoaDAO;

        public PessoaController(PessoaDAO pessoaDAO)
        {
            _pessoaDAO = pessoaDAO;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CadastroCliente()
        {
            return View();
        }
        public IActionResult CadastroColunista()
        {
            return View();
        }

        public IActionResult CadastrarCliente()
        {
       
            //enviar mensagem para a tela
            ModelState.AddModelError("", "Um produto já foi cadastrado com este Nome");
            return View();
            //return View();
        }


        [HttpPost]
        public IActionResult CadastrarCliente(Pessoa p)
        {
            if (_pessoaDAO.CadastrarPessoa(p))
            {
                return RedirectToAction("Index","Home");

            }
            //enviar mensagem para a tela
            ModelState.AddModelError("", "Um produto já foi cadastrado com este Nome");
            return View(p);
            //return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int Cpf,  string Password)
        {
            Pessoa pessoa = _pessoaDAO.BuscarPessoaPorCpf(Cpf);

            if (pessoa != null)
            {
                if (Password == pessoa.Password)
                {
                    return View("HomeCliente");
                }
            }
            return View();
        }

    }
}