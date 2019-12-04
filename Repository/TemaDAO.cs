using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Repository
{
   public class TemaDAO
    {

        private static Context ctx;

        public TemaDAO(Context context)
        {
            ctx = context;
        }

        public List<Tema> ListarTemas()
        {
            return ctx.Temas.ToList();
        }

        public Tema BuscarTemaPorId(int Id)
        {
            return ctx.Temas.FirstOrDefault(x => x.IdTema.Equals(Id));
        }
        public Tema BuscarTemaPorNome(string novoTema)
        {
            return ctx.Temas.FirstOrDefault(x => x.tema.Equals(novoTema));
        }

        public bool AdicionarTema(string tema)
        {
            Tema t = new Tema();
            t.tema = tema;
            if (BuscarTemaPorNome(tema) != null)
            {
                return false;
            }
            ctx.Temas.Add(t);
            ctx.SaveChanges();
            return true;

            ;
        }
    }

    

}
