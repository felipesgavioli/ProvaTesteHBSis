

using System.Data.Entity.ModelConfiguration;
using ProvaHBSis.Domain.Entities;

namespace ProvaHBSis.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CpfCnpj)
                .IsRequired();

            Property(c => c.Telefone)
                .IsRequired();

        }
    }
}
