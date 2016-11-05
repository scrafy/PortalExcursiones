using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionDestino : EntityTypeConfiguration<destino>
    {
        public ConfiguracionDestino()
        {
           
              Property(e => e.nombre)
              .IsUnicode(false);

           
                HasMany(e => e.excursionesactividades)
                .WithRequired(e => e.destino)
                .HasForeignKey(e => e.destino_id)
                .WillCascadeOnDelete(false);
        }
    }
}
