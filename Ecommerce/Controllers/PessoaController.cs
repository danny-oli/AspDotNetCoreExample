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

        public IActionResult HomeColunista()
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
        public IActionResult CadastrarCliente(Cliente c)
        {
            if (_pessoaDAO.CadastrarPessoa(c))
            {
                return RedirectToAction("Index","Home");

            }
            //enviar mensagem para a tela
            ModelState.AddModelError("", "Um produto já foi cadastrado com este Nome");
            return View(c);
            //return View();
        }

        public IActionResult CadastrarColunista()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CadastrarColunista(Colunista c)
        {
            if (_pessoaDAO.CadastrarPessoa(c))
            {
                return RedirectToAction("Index", "Home");

            }
            //enviar mensagem para a tela
            ModelState.AddModelError("", "Esta pessoa ja foi cadastrada.");
            return View(c);
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
                    if (pessoa.Tipo.Equals("Cliente"))
                    {
                        return View("HomeCliente");
                    }
                    else
                    {
                        return View("HomeColunista");
                    }
                    
                }
            }
            return View();
        }


        public IActionResult CadastrarArtigo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarArtigos(Colunista c)
        {

            return View();
        }

    }

    
}