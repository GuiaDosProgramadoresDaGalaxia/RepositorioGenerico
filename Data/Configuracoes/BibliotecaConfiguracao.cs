using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuracoes
{
    public class BibliotecaConfiguracao : EntityTypeConfiguration<Biblioteca>
    {
        public BibliotecaConfiguracao()
        {
            Property(c => c.Nome).IsRequired();
            Property(c => c.Endereco).IsRequired();
        }
    }
}
