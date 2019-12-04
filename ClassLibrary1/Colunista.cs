using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

   



    public class Colunista :  Pessoa
    {
        public Colunista()
        {

          
        }

        
        public int SaldoColunista { get; set; }





    }
}
