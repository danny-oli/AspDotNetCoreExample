using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Artigo
    {
       
       

        public Artigo()
        {

        }
        public Artigo(Pessoa p)
        {
            
         
            CriadoEm = DateTime.Now;
            
        }

        [Key]
        public int IdArtigo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string NomeColunista { get; set; }
        public string Tema { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int Valor { get; set; }
        public int Paginas { get; set; }


        public override string ToString()
        {
            return "Colunista: " + NomeColunista + " | Titulo: " + Titulo + " Texto: " + Texto;
        }
    }


}