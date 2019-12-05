using System;
using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class ContratacaoColunista
    {
        public ContratacaoColunista()
        {

        }

        public ContratacaoColunista(Colunista c, Artigo a)
        {
            DataHoraContratacao = DateTime.Now;
            ColunistaAutor = c;
            Artigo = a;
           
        }

        [Key]
        public int IdContratacaoColunista { get; set; }
        public Colunista ColunistaAutor { get; set; }
        public DateTime DataHoraContratacao { get; set; }
        public Artigo Artigo { get; set; }
        
    }
}
