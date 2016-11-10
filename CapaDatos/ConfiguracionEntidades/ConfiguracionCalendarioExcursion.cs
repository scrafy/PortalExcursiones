using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionCalendarioExcursion : EntityTypeConfiguration<calendarioexcursion>
    {
        public ConfiguracionCalendarioExcursion()
        {

          
              HasMany(e => e.guias)
              .WithRequired(e => e.calendarioexcursion)
              .HasForeignKey(e => new { e.exact_id, e.fecha })
              .WillCascadeOnDelete(false);

          
                HasMany(e => e.puntosrecogida)
                .WithRequired(e => e.calendarioexcursion)
                .HasForeignKey(e => new { e.exact_id, e.fecha })
                .WillCascadeOnDelete(false);

        
                HasMany(e => e.reservas)
                .WithRequired(e => e.calendarioexcursion)
                .HasForeignKey(e => new { e.exact_id, e.fecha })
                .WillCascadeOnDelete(false);
        }
    }
}
