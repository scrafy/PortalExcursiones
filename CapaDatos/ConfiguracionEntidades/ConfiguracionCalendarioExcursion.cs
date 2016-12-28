using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionCalendarioExcursion : EntityTypeConfiguration<calendarioexcursion>
    {
        public ConfiguracionCalendarioExcursion()
        {
            
                HasMany(e => e.reservas)
                .WithRequired(e => e.calendarioexcursion)
                .HasForeignKey(e=>e.calendario_id)
                .WillCascadeOnDelete(false);
        }
    }
}
