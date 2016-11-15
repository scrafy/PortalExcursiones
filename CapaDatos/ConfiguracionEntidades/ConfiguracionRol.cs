using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CapaDatos.ConfiguracionEntidades
{


    public class ConfiguracionRol : EntityTypeConfiguration<IdentityRole>
    {
        public ConfiguracionRol()
        {
            ToTable("rol");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id");
            Property(e => e.Name).HasColumnName("nombre").IsRequired().HasMaxLength(60);
            HasMany(e => e.Users).WithRequired().HasForeignKey(e => e.RoleId).WillCascadeOnDelete(false);

        }
    }
}

