

using System.Data.Entity.ModelConfiguration;
using ProvaHBSis.Domain.Entities;

namespace ProvaHBSis.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.UsuarioId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(100); ;

        }
    }
}
