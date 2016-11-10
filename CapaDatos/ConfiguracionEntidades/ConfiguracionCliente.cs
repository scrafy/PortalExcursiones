using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionCliente : EntityTypeConfiguration<cliente>
    {
        public ConfiguracionCliente()
        {
            
              Property(e => e.numidentificacion)
              .IsUnicode(false);

           
                Property(e => e.infadicional)
                .IsUnicode(false);

           
                HasMany(e => e.reservas)
                .WithRequired(e => e.cliente)
                .HasForeignKey(e => e.cliente_id)
                .WillCascadeOnDelete(false);
        }
    }
}
