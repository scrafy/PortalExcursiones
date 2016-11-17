using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionUsuario : EntityTypeConfiguration<usuario>
    {
        public ConfiguracionUsuario()
        {
            ToTable("usuario");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id");
            Property(e => e.EmailConfirmed).HasColumnName("confirmacionemail").IsRequired();
            Property(e => e.SecurityStamp).HasColumnName("securitystamp").HasColumnType("text").IsOptional();
            Property(e => e.PhoneNumberConfirmed).HasColumnName("confirmaciontelefono").IsRequired();
            Property(e => e.TwoFactorEnabled).HasColumnName("twofactorenabled").IsRequired();
            Property(e => e.LockoutEndDateUtc).HasColumnName("lockoutenddateutc").HasColumnType("DateTime").IsOptional();
            Property(e => e.LockoutEnabled).HasColumnName("lockoutenabled").IsRequired();
            Property(e => e.AccessFailedCount).HasColumnName("numaccesosfallidos").HasColumnType("int").IsRequired();
            Property(e => e.nombre).IsUnicode(false);
            Property(e => e.primerapellido).IsUnicode(false);
            Property(e => e.segundoapellido).IsUnicode(false);
            Property(e => e.direccion1).IsUnicode(false);
            Property(e => e.direccion2).IsUnicode(false);
            HasOptional(e => e.cliente).WithRequired(e => e.usuario);
            HasOptional(e => e.colaborador).WithRequired(e => e.usuario);
            HasOptional(e => e.guia).WithRequired(e => e.usuario);
            HasOptional(e => e.proveedor).WithRequired(e => e.usuario);
            HasMany(e => e.Claims).WithRequired().HasForeignKey(e => e.UserId).WillCascadeOnDelete(false);
            HasMany(e => e.Logins).WithRequired().HasForeignKey(e => e.UserId).WillCascadeOnDelete(false);
            HasMany(e => e.Roles).WithRequired().HasForeignKey(e => e.UserId).WillCascadeOnDelete(false);
        }
    }
}
