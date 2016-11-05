using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionAlquilerVehiculo : EntityTypeConfiguration<alquilervehiculo>
    {
        public ConfiguracionAlquilerVehiculo()
        {
            
               Property(e => e.observaciones)
               .IsUnicode(false);

            
                HasMany(e => e.recogidasdevoluciones)
                .WithRequired(e => e.alquilervehiculo)
                .WillCascadeOnDelete(false);

         
                HasMany(e => e.vehiculos)
                .WithRequired(e => e.alquilervehiculo)
                .WillCascadeOnDelete(false);
        }
    }
}
