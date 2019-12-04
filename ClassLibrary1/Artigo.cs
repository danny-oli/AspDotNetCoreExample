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
        public Artigo(Colunista c, Tema t)
        {
            this.ColunistaAutor = c;
            this.Tema = t;
            CriadoEm = DateTime.Now;
            
        }

        [Key]
        public int IdArtigo { get; set; }
        public DateTime CriadoEm { get; set; }
        public Colunista ColunistaAutor { get; set; }
        public Tema Tema { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int Valor { get; set; }
        public int Paginas { get; set; }


        public override string ToString()
        {
            return "Colunista: " + ColunistaAutor.Nome + " | Titulo: " + Titulo + " Texto: " + Texto;
        }
    }


}