using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionProvincia : EntityTypeConfiguration<provincia>
    {
        public ConfiguracionProvincia()
        {
           
              Property(e => e.nombre)
              .IsUnicode(false);

           
                HasMany(e => e.localidades)
                .WithRequired(e => e.provincia)
                .HasForeignKey(e => e.provincia_id)
                .WillCascadeOnDelete(false);
        }
    }
}
