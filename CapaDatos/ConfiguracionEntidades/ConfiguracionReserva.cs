using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionReserva : EntityTypeConfiguration<reserva>
    {
        public ConfiguracionReserva()
        {
            
                Property(e => e.factura)
                .IsUnicode(false);

            
                HasOptional(e => e.reservaexcursionactividad)
                .WithRequired(e => e.reserva);

           
                HasOptional(e => e.reservavehiculo)
                .WithRequired(e => e.reserva);
        }
    }
}

