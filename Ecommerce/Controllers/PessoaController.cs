using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Repository;

namespace JornalOnline.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaDAO _pessoaDAO;
        private readonly UserManager<UsuarioLogado> userManager;
        private readonly SignInManager<UsuarioLogado> signInManager;

        public PessoaController(PessoaDAO pessoaDAO, UserManager<UsuarioLogado> u, SignInManager<UsuarioLogado> s)
        {
            _pessoaDAO = pessoaDAO;
            userManager = u;
            signInManager = s;
        }

        public IActionResult Index()
        {

            // ViewBag.Pessoa = _pessoaDAO.BuscarPessoaPorCpf(userManager.GetUserName(User));
            return View(_pessoaDAO.ListarPessoas());
        }

        public IActionResult Login()
        {
            return View("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Login(Pessoa p)
        {
            // var result = await signInManager.PasswordSignInAsync(p.CPf, p.Password, true, lockoutOnFailure: false);
            // if (result.Succeeded)
            // {

            Pessoa usuario = _pessoaDAO.BuscarPessoaPorCpf(p.CPf);

            if (usuario.Tipo == "Colunista")
            {
               
                return RedirectToAction("HomeColunista");
            }
            else
            {
                return RedirectToAction("HomeCliente", p);
            }
            //  }

            ModelState.AddModelError("", "Falha no login");
            return RedirectToAction("Index", "Home");
        }


        public IActionResult HomeColunista()
        {
            ViewBag.Pessoas = new SelectList(_pessoaDAO.ListarPessoas(), "PessoaId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult HomeColunista(Pessoa p)
        {
            Pessoa pessoa = _pessoaDAO.BuscarPessoaPorCpf(p.CPf);

            if (pessoa != null)
            {
                if (p.Password == pessoa.Password)
                {
                    ViewBag.Pessoas = new SelectList(_pessoaDAO.ListarPessoas(), "PessoaId", "Nome");
                    return View(_pessoaDAO.BuscarPessoaPorCpf(p.CPf));
                }
            }
            else
            {
                ModelState.AddModelError("", "Dados Incorretos!");
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Usuário não encontrado!");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult HomeCliente()
        {

            return View();
        }

        [HttpPost]
        public IActionResult HomeCliente(string cpf, string password)
        {

            return View(_pessoaDAO.BuscarPessoaPorCpf(cpf));
        }

        public IActionResult CadastroCliente()
        {
            Pessoa p = new Pessoa();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco =
                    JsonConvert.DeserializeObject<Endereco>
                    (resultado);
                p.Endereco = endereco;
            }
            return View(p);
        }


        public IActionResult CadastroColunista()
        {
            Pessoa p = new Pessoa();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco =
                    JsonConvert.DeserializeObject<Endereco>
                    (resultado);
                p.Endereco = endereco;
            }
            else
            {
                ModelState.AddModelError("", "Endereço Veio Vazio");
                return View(p);
            }

            return View(p);
        }

        [HttpPost]
        public IActionResult BuscarCep(Pessoa p)
        {
            string url = "https://api.postmon.com.br/v1/cep/" +
               p.Endereco.Cep;
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);

            return RedirectToAction(nameof(CadastroColunista));
        }



        [HttpPost]

        public async Task<IActionResult> CadastroColunistaPost(Pessoa pessoa)
        {
            if (pessoa.Tipo == "Colunista")
            {
                //Criar um objeto do usuario logado e passar obrigatoriamente email e username
                UsuarioLogado userLogado = new UsuarioLogado()
                {
                    Email = pessoa.Password,
                    UserName = pessoa.Password
                };
                //Cadastra o usuario na tabela do Identity
                //IdentityResult result = await userManager.CreateAsync(userLogado, pessoa.Password);
                //Testa o resultado do cadastro
                // if (result.Succeeded)
                


                    Colunista c1 = new Colunista
                    {
                        Nome = pessoa.Nome,
                        Endereco = pessoa.Endereco,
                        CPf = pessoa.CPf,
                        Password = pessoa.Password,
                        Tipo = pessoa.Tipo
                    };
                    if (_pessoaDAO.CadastrarPessoa(c1))
                    {

                        //Logar usuario no sistema
                        //await signInManager.SignInAsync(userLogado, isPersistent: false);
                        return RedirectToAction("HomeColunista");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cpf já Cadastrado");
                    }

            }
            else
            {
                    Cliente p1 = new Cliente
                    {
                        Nome = pessoa.Nome,
                        Endereco = pessoa.Endereco,
                        CPf = pessoa.CPf,
                        Password = pessoa.Password,
                        Tipo = pessoa.Tipo
                    };
                    if (_pessoaDAO.CadastrarPessoa(p1))
                    {
                        //Logar usuario no sistema
                        //wait signInManager.SignInAsync(userLogado, isPersistent: false);
                        return RedirectToAction("HomeCliente");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cpf já Cadastrado");
                    }
                
            }

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
                return RedirectToAction("Index", "Home");

            }
            //enviar mensagem para a tela
            ModelState.AddModelError("", "Um produto já foi cadastrado com este Nome");
            return View(c);
            //return View();
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