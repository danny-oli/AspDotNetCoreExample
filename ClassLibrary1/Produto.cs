using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    //Annotations ASP.NET Core para buscar novas formas de validações como a quantidade, e vazio utilizadas abaixo

    [Table("Produtos")]
    public class Produto
    {

        public Produto()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int IdProduto { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage ="Campo obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage ="Necessário no mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage ="Utilize no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Preço:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 1000, ErrorMessage =("Não é possível cadastrar produtos com mais de R$ 1.000,00."))]
        public double? Preco { get; set; }

        [Display(Name = "Quantidade:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 1000, ErrorMessage = ("Não é possível cadastrar mais de 1000 peças do mesmo produto"))]
        public int? Quantidade { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
