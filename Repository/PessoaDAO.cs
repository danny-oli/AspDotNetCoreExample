using Domain;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Repository
{
   public  class PessoaDAO
    {


        private readonly Context ctx;

        public PessoaDAO(Context context) {
            ctx = context;
        }

        public bool CadastrarPessoa(Pessoa p)
        {
            if (BuscarPessoaPorNome(p) == null)
            {
                ctx.Pessoas.Add(p);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }


        public Pessoa BuscarPessoaPorNome(Pessoa p)
        {
            return ctx.Pessoas.FirstOrDefault(x => x.Nome.Equals(p.Nome));
        }


        public Pessoa BuscarPessoaPorCpf(string cpf)
        {
            return ctx.Pessoas.FirstOrDefault(x => x.CPf.Equals(cpf));

          
        }

        public bool Login(Pessoa p, string senha)
        {
            Pessoa existe = ctx.Pessoas.FirstOrDefault(x => x.CPf.Equals(p.CPf));

            if (!existe.Equals(""))
            {
                if (p.Password.Equals(senha))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Pessoa> ListarPessoas ()
        {
            return ctx.Pessoas.ToList();
        }

        //public void AtualizarSaldo(Pessoa p)
        //{

        //    ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
        //    ctx.SaveChanges();
               
        //}

    }
}
