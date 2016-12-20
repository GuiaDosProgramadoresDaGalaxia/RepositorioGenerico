using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuracoes
{
    public class SecaoConfiguracao : EntityTypeConfiguration<Secao>
    {
        public SecaoConfiguracao()
        {
            Property(c => c.Nome).IsRequired();
            Property(c => c.Local).IsRequired();

            HasRequired(c => c.Biblioteca)
                .WithMany(a => a.Secoes)
                .HasForeignKey(c => c.BibliotecaId);
        }
    }
}
