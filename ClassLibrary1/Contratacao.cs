using System;
using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class Contratacao
    {
        public Contratacao()
        {

        }

        public Contratacao(Cliente c, Artigo a)
        {
            DataHoraContratacao = DateTime.Now;
            ClienteContrata = c;
            Artigo = a;
            ValorContratacao = a.Valor;
        }

        [Key]
        public int IdContratacao { get; set; }
        public Cliente ClienteContrata{ get; set; }
        public DateTime DataHoraContratacao { get; set; }
        public double  ValorContratacao { get; set; }
        public Artigo Artigo { get; set; }
        
    }
}
