using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionTipoVehiculo : EntityTypeConfiguration<tipovehiculo>
    {
        public ConfiguracionTipoVehiculo()
        {
            
               Property(e => e.nombre)
               .IsUnicode(false);

           
                HasMany(e => e.vehiculos)
                .WithRequired(e => e.tipovehiculo)
                .HasForeignKey(e => e.tipovehiculo_id)
                .WillCascadeOnDelete(false);
        }
    }
}

