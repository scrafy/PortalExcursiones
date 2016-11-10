using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionReservaExcursionActividad : EntityTypeConfiguration<reservaexcursionactividad>
    {
        public ConfiguracionReservaExcursionActividad()
        {
            
            Property(e => e.direccion)
            .IsUnicode(false);

           
            Property(e => e.nombrehotel)
            .IsUnicode(false);

           
            Property(e => e.observaciones)
            .IsUnicode(false);

        }
    }
}

