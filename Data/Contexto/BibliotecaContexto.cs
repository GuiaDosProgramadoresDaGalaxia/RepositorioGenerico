using Data.Configuracoes;
using Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Contexto
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto() : base("BibliotecaContexto")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Secao> Secoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AutorConfiguracao());
            modelBuilder.Configurations.Add(new BibliotecaConfiguracao());
            modelBuilder.Configurations.Add(new LivroConfiguracao());
            modelBuilder.Configurations.Add(new SecaoConfiguracao());

            base.OnModelCreating(modelBuilder);
        }
    }
}
