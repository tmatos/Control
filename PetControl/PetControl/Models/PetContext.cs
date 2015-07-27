using System.Data.Entity;

namespace PetControl.Models
{
    public class PetContext : DbContext
    {
        public PetContext()
            : base("name=PetControl")
        {

        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Contato> Contato { get; set; }

        // opativo
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
