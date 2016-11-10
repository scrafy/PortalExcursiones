using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionProveedor : EntityTypeConfiguration<proveedor>
    {
        public ConfiguracionProveedor()
        {
            
               Property(e => e.nombreempresa)
               .IsUnicode(false);

           
                Property(e => e.cif)
                .IsUnicode(false);

            
                Property(e => e.observaciones)
                .IsUnicode(false);

           
                Property(e => e.lat)
                .IsUnicode(false);

           
                Property(e => e.lng)
                .IsUnicode(false);

            
                HasMany(e => e.reservas)
                .WithRequired(e => e.proveedor)
                .HasForeignKey(e => e.proveedor_id)
                .WillCascadeOnDelete(false);

           
                HasMany(e => e.configuraciones)
                .WithRequired(e => e.proveedor)
                .HasForeignKey(e => e.proveedor_id)
                .WillCascadeOnDelete(false);
        }
    }
}

