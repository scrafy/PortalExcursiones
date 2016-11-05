using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionEstadoExcursion : EntityTypeConfiguration<estadoexcursion>
    {
        public ConfiguracionEstadoExcursion()
        {
           
             Property(e => e.nombre)
             .IsUnicode(false);

            
                HasMany(e => e.calendarioexcursion)
                .WithRequired(e => e.estadoexcursion)
                .HasForeignKey(e => e.estadoexcursion_id)
                .WillCascadeOnDelete(false);
        }
    }
}


