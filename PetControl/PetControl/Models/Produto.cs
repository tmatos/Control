using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetControl.Models
{
    [Serializable]
    public class Produto
    {
        [ScaffoldColumn(false)]
        public int ProdutoID { get; set; }

        [Required, StringLength(100), Display(Name = "Nome")]
        public string ProdutoNome { get; set; }

        [Required, StringLength(10000), Display(Name = "Descrição do produto"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public string CaminhoFoto { get; set; }

        [Display(Name = "Preço")]
        public double? PrecoUnitario { get; set; }

        [NotMapped]
        public double? PrecoUnitarioComDesconto5
        {
            get { return PrecoUnitario * 0.95; }
        }

        public int? CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }
    }

    [Serializable]
    public class Categoria
    {
        [ScaffoldColumn(false)]
        public int CategoriaID { get; set; }

        [Required, StringLength(100), Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [Display(Name = "Descrição do produto")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}