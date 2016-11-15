using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CapaDatos.ConfiguracionEntidades
{


    public class ConfiguracionClaim : EntityTypeConfiguration<IdentityUserClaim>
    {
        public ConfiguracionClaim()
        {
            ToTable("claim");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id");
            Property(e => e.UserId).HasColumnName("usuario_id");
            Property(e => e.ClaimType).HasColumnName("tipo").IsOptional().HasColumnType("text").HasColumnType("varchar");
            Property(e => e.ClaimValue).HasColumnName("valor").IsOptional().HasColumnType("text").HasColumnType("varchar");

        }
    }
}

