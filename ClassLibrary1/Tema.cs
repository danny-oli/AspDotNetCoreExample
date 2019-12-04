using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain
{
    public class Tema
    {
        
        public Tema()
        {

        }

        [Key]
        public int IdTema { get; set; }
        public string tema { get; set; }




    }
}