using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
   public class ArtigoDAO
    {
        private readonly Context ctx;

        public ArtigoDAO(Context context)  {
            ctx = context;
        }

        



        public bool CadastrarArtigo(Artigo a)
        {
            ctx.Artigos.Add(a);
            ctx.SaveChanges();
            return true;

        }

        public  List<Artigo> ListarArtigos()
        {

            return ctx.Artigos.ToList();
        }

        public  Artigo BuscarArtigoPorId(int id)
        {
           // return ctx.Artigos.Include("ColunistaAutor").Include("Tema").FirstOrDefault(x => x.IdArtigo.Equals(id));
            return ctx.Artigos.FirstOrDefault(x => x.IdArtigo.Equals(id));
        }

        public  void ExcluirArtigo (Artigo a)
        {
            ctx.Artigos.Remove(a);
            ctx.SaveChanges();
        }
        
       

        //public  void EditarArtigo (Artigo a)
        //{
        //    ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
        //    ctx.SaveChanges();
        //}
    }


}
