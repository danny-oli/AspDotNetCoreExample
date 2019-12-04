using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{

    public class ProdutoDAO
    {

        private readonly Context _context;

        public ProdutoDAO(Context context)
        {
            _context = context;
        }


        public bool Cadastrar(Produto p)
        {
            if (BuscarProdutoPorNome(p) == null)
            {
                _context.Produtos.Add(p);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;   
            }
            
        }

        public List <Produto> ListarProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produto BuscarProdutoPorId (int? id)
        {
            return _context.Produtos.Find(id);
        }


        public void RemoverProduto (Produto p)
        {
            _context.Produtos.Remove(p);
            _context.SaveChanges();
        }

        public void AlterarProduto (Produto p)
        {
            _context.Update(p);
            _context.SaveChanges();
        }

        public Produto BuscarProdutoPorNome(Produto p)
        {
            return _context.Produtos.FirstOrDefault(x => x.Nome.Equals(p.Nome));
        }
    }
}
