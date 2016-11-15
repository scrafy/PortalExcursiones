using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CapaDatos.ConfiguracionEntidades
{


    public class ConfiguracionLogin : EntityTypeConfiguration<IdentityUserLogin>
    {
        public ConfiguracionLogin()
        {
            ToTable("login");
            ToTable("login").HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });
            ToTable("login").Property(e => e.LoginProvider).HasColumnName("proveedor");
            ToTable("login").Property(e => e.ProviderKey).HasColumnName("key");
            ToTable("login").Property(e => e.UserId).HasColumnName("usuario_id");

        }
    }
}

