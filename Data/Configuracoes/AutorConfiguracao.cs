using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuracoes
{
    public class AutorConfiguracao : EntityTypeConfiguration<Autor>
    {
        public AutorConfiguracao()
        {
            Property(c => c.Nome).IsRequired();

            HasMany(c => c.Bibliotecas)
                .WithMany(a => a.Autores)
                .Map(t => t.ToTable("AutoresBibliotecas"));
        }
    }
}
