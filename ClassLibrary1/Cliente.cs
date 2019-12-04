using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

   

    public class Cliente : Pessoa
    {
        public List<Artigo> Artigos { get; set; }
        public List<Colunista> ColunistasContratados { get; set; }
        public int Saldo { get; set; }



    }


}
