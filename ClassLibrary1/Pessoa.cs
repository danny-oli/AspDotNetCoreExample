﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    //[Table("Pessoa")] // FORMA DE CLASSIFICAR UMA ENTIDADE NO BANCO (@ENTITY DO JAVA)

    public class Pessoa
    {

        

        public Pessoa()
        {
            
        }

        //[Key] Anotacao para alterar o nome do atributo na Tabela do BD
        [Key]
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string CPf { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public Endereco Endereco { get; set; }
        public int ArtigoPaginas { get; set; }
        public string ArtigoTitulo { get; set; }
        public string ArtigoTexto { get; set; }
        public string ArtigoTema { get; set; }
        public int ArtigoValor { get; set; }
        



        //public override string ToString()
        //{
        //    return "Nome: " + Nome + " | Quantidade: " + Quantidade + " | Preço: " + Preco.ToString("C2") + " | Categoria: " + Cat.Nome;
        //}
    }
}
