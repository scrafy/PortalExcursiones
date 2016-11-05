using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionFoto : EntityTypeConfiguration<foto>
    {
        public ConfiguracionFoto()
        {
            Property(e => e.url)
            .IsUnicode(false);

           
            Property(e => e.nombre)
            .IsUnicode(false);

        }
    }
}
