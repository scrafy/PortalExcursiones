using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionFotoConfiguracion : EntityTypeConfiguration<fotoconfiguracion>
    {
        public ConfiguracionFotoConfiguracion()
        {
            Property(e => e.url)
            .IsUnicode(false);

           
            Property(e => e.nombre)
            .IsUnicode(false);

        }
    }
}
