using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionCategoriaExcursion : EntityTypeConfiguration<categoriaexcursion>
    {
        public ConfiguracionCategoriaExcursion()
        {
           
              Property(e => e.nombre)
              .IsUnicode(false);

           
                HasMany(e => e.excursionesactividades)
                .WithOptional(e => e.categoriaexcursion)
                .HasForeignKey(e => e.tipoexcursion_id);
        }
    }
}


