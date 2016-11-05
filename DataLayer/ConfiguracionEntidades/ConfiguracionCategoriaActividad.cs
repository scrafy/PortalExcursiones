using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionCategoriaActividad : EntityTypeConfiguration<categoriactividad>
    {
        public ConfiguracionCategoriaActividad()
        {
           
              Property(e => e.nombre)
              .IsUnicode(false);

          
                HasMany(e => e.excursionesactividades)
                .WithOptional(e => e.categoriactividad)
                .HasForeignKey(e => e.tipoactividad_id);
        }
    }
}
