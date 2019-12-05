using System;
using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class ContratacaoColunista
    {
        public ContratacaoColunista()
        {

        }

        public ContratacaoColunista( Artigo a)
        {
            DataHoraContratacao = DateTime.Now;
           
            Artigo = a;
           
        }

        [Key]
        public int IdContratacaoColunista { get; set; }
        public string ColunistaAutor { get; set; }
        public DateTime DataHoraContratacao { get; set; }
        public Artigo Artigo { get; set; }
        
    }
}
