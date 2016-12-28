using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionPuntoRecogida : EntityTypeConfiguration<puntorecogida>
    {
        public ConfiguracionPuntoRecogida()
        {
           
            Property(e => e.nombre)
            .IsUnicode(false);

           
            Property(e => e.lat)
            .IsUnicode(false);

            
            Property(e => e.lng)
            .IsUnicode(false);

           
            Property(e => e.direccion)
            .IsUnicode(false);

            HasMany(e => e.configuraciones)
            .WithRequired(e => e.punto)
            .WillCascadeOnDelete(false);

            HasMany(e => e.reservas)
           .WithOptional(e => e.punto)
           .HasForeignKey(e => e.punto_id)
           .WillCascadeOnDelete(false);
        }
    }
}
