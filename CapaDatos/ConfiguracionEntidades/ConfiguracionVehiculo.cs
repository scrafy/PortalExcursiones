using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionVehiculo : EntityTypeConfiguration<vehiculo>
    {
        public ConfiguracionVehiculo()
        {
            
              Property(e => e.marca)
              .IsUnicode(false);

            
                Property(e => e.modelo)
                .IsUnicode(false);

            
                Property(e => e.matircula)
                .IsUnicode(false);

            
                Property(e => e.imagen)
                .IsUnicode(false);

            
                Property(e => e.permisorequerido)
                .IsUnicode(false);

            
                HasMany(e => e.reservas)
                .WithRequired(e => e.vehiculo)
                .HasForeignKey(e => e.vehiculo_id)
                .WillCascadeOnDelete(false);
        }
    }
}
