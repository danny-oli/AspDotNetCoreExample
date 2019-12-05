using Domain;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Repository
{
    public class ContratacaoDAO
    {
        public static List<Contratacao> listContratacoes;
        public static List<ContratacaoColunista> listContratacoesColunista;
        private readonly Context ctx;

        public ContratacaoDAO(Context context)
        {
            ctx = context;
        }

        public bool SalvarContratacao(Contratacao c)
        {
           ctx.Contratacoes.Add(c);
            ctx.SaveChanges();
            return true;
           
        }

        public bool SalvarContratacaoColunista(ContratacaoColunista c)
        {
            ctx.ContratacoesColunista.Add(c);
            ctx.SaveChanges();
            return true;

        }


        public  Contratacao BuscarContratoPorId(Contratacao c)
        {
            return ctx.Contratacoes.FirstOrDefault(x => x.IdContratacao.Equals(c.IdContratacao));
            
        }

        public  bool ArtigoJaContratadoPorCliente(Artigo a, Cliente c)
        {
            listContratacoes = ctx.Contratacoes.ToList();
            
            if (!listContratacoes.Equals(null))
            {
                foreach (Contratacao contratacao in listContratacoes)
                {
                    if (contratacao.Artigo.IdArtigo.Equals(a.IdArtigo))
                    {
                        if (contratacao.ClienteContrata.PessoaId.Equals(c.PessoaId))
                        {
                            return true;
                        }

                    }

                }


            }
            return false;

           
            
        }

        public List<Contratacao> BuscarListaDeContratacoes()
        {
           // return ctx.Contratacoes.Include("clienteContrata").Include("Artigo.ColunistaAutor").ToList();
           return ctx.Contratacoes.ToList();
        }

        public  List<Contratacao> ContratacoesPorCliente(Pessoa p)
        {
            List<Contratacao> contratadosPorCliente = new List<Contratacao>();
            foreach (Contratacao c in BuscarListaDeContratacoes())
            {
                if (p.PessoaId.Equals(c.ClienteContrata.PessoaId))
                {
                    contratadosPorCliente.Add(c);

                }


            }
            return contratadosPorCliente;

        }
        
        public bool ArtigoNaoContratado (Artigo a)
        {
            List<Contratacao> todasContratacoes = BuscarListaDeContratacoes();
            foreach (Contratacao c in todasContratacoes)
            {
                if (c.Artigo.Equals(a))
                {
                    return false;
                }
            }
            return true;
        }

        public List<dynamic> ContratacoesPorClienteDynamic(Cliente cliente)
        {
            List<dynamic> contratadosClienteDynamic = new List<dynamic>();

            foreach (Contratacao c in BuscarListaDeContratacoes())
            {
                if (cliente.PessoaId.Equals(c.ClienteContrata.PessoaId))
                {
                    dynamic d = new
                    {
                        nomeColunista = c.Artigo.NomeColunista,
                        titulo = c.Artigo.Titulo,
                        //temaDynamic = c.Artigo.Tema.tema,
                        texto = c.Artigo.Texto,
                    };

                    contratadosClienteDynamic.Add(d);

                }


            }
            return contratadosClienteDynamic;

        }

    }

}
