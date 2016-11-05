using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionPais : EntityTypeConfiguration<pais>
    {
        public ConfiguracionPais()
        {
           
               Property(e => e.nombre)
               .IsUnicode(false);

           
                HasMany(e => e.provincias)
                .WithRequired(e => e.pais)
                .HasForeignKey(e => e.pais_id)
                .WillCascadeOnDelete(false);
        }
    }
}
