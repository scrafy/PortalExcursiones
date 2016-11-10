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

            
                HasMany(e => e.excursiones)
                .WithRequired(e => e.puntorecogida)
                .HasForeignKey(e => e.puntorecogida_id)
                .WillCascadeOnDelete(false);
        }
    }
}
