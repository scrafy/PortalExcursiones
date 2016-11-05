using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;
namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionConfiguracion : EntityTypeConfiguration<configuracion>
    {
        public ConfiguracionConfiguracion()
        {
           
              Property(e => e.nombre)
              .IsUnicode(false);

           
                Property(e => e.video)
                .IsUnicode(false);

           
                Property(e => e.tadvisor)
                .IsUnicode(false);

           
                Property(e => e.lat)
                .IsUnicode(false);

           
                Property(e => e.lng)
                .IsUnicode(false);

           
                Property(e => e.logo)
                .IsUnicode(false);

          
                HasOptional(e => e.alquilervehiculo)
                .WithRequired(e => e.configuracion);

           
                HasOptional(e => e.excursionactividad)
                .WithRequired(e => e.configuracion);

           
                HasMany(e => e.fotos)
                .WithRequired(e => e.configuracion)
                .HasForeignKey(e => e.configuracion_id)
                .WillCascadeOnDelete(false);
        }
    }

}
