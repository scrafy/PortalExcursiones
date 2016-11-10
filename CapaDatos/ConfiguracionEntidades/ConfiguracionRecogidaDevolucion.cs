using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionRecogidaDevolucion : EntityTypeConfiguration<recogidadevolucion>
    {
        public ConfiguracionRecogidaDevolucion()
        {
           
                Property(e => e.lat)
                .IsUnicode(false);

           
                Property(e => e.lng)
                .IsUnicode(false);

           
                Property(e => e.direccion)
                .IsUnicode(false);

           
                Property(e => e.telefono)
                .IsUnicode(false);

           
                HasMany(e => e.devoluciones)
                .WithRequired(e => e.puntodevolucion)
                .HasForeignKey(e => e.puntorecogida_id)
                .WillCascadeOnDelete(false);

            
                HasMany(e => e.recogidas)
                .WithRequired(e => e.puntorecogida)
                .HasForeignKey(e => e.puntodevolucion_id)
                .WillCascadeOnDelete(false);
        }
    }
}
