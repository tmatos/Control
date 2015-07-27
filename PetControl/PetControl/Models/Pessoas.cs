using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PetControl.Models
{
    [Serializable]
    public abstract class Pessoa
    {
        public Pessoa()
        {
            this.Contatos = new List<Contato>();
        }

        [Key]
        [ScaffoldColumn(false)]
        public int PessoaID { get; set; }

        [Required, StringLength(100), Display(Name = "Nome")]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public int Idade
        {
            get { return Convert.ToInt32((DateTime.Today - DataNascimento).Days / 365.25); }
        }

        public virtual IList<Contato> Contatos { get; set; }
    }

    [Serializable]
    [Table("Funcionarios")]
    public class Funcionario : Pessoa
    {
        [Required]
        [Index(IsUnique = true)]
        public int Matricula { get; set; }

        [Required]
        public DateTime DataAdmissao { get; set; }

        [Required]
        public double Salario { get; set; }
    }

    [Serializable]
    [Table("Clientes")]
    public class Cliente : Pessoa
    {
        [Index(IsUnique = true)]
        public long Cpf { get; set; }
    }

    [Serializable]
    public class Contato
    {
        [ScaffoldColumn(false)]
        public int ContatoID { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }

        [StringLength(300)]
        public string Valor { get; set; }

        public int PessoaID { get; set; }

        [ForeignKey("PessoaID")]
        public Pessoa Pessoa { get; set; }
    }
}
