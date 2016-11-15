using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CapaDatos.ConfiguracionEntidades
{


    public class ConfiguracionUsuarioRol : EntityTypeConfiguration<IdentityUserRole>
    {
        public ConfiguracionUsuarioRol()
        {
            ToTable("usuario_rol");
            HasKey(e => new { e.UserId, e.RoleId });
            Property(e => e.RoleId).HasColumnName("role_id");
            Property(e => e.UserId).HasColumnName("usuario_id");

        }
    }
}

