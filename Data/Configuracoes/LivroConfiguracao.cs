using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuracoes
{
    public class LivroConfiguracao : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguracao()
        {
            Property(c => c.Nome).IsRequired();
            Property(c => c.Tipo).IsRequired();

            HasRequired(c => c.Biblioteca)
                .WithMany(a => a.Livros)
                .HasForeignKey(c => c.BibliotecaId);

            HasRequired(c => c.Autor)
                .WithMany(a => a.Livros)
                .HasForeignKey(c => c.AutorId);

            HasRequired(c => c.Secao)
                .WithMany(a => a.Livros)
                .HasForeignKey(c => c.SecaoId);
        }
    }
}
