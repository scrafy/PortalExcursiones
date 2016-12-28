using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionFacturaItem : EntityTypeConfiguration<facturaitem>
    {
        public ConfiguracionFacturaItem()
        {

            Property(e => e.nombre)
            .IsUnicode(false);


            HasMany(e => e.excursiones)
            .WithRequired(e => e.item)
            .HasForeignKey(e => e.item_id)
            .WillCascadeOnDelete(false);
        }
    }
}
