using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionItem : EntityTypeConfiguration<item>
    {
        public ConfiguracionItem()
        {
           
             Property(e => e.nombre)
             .IsUnicode(false);

           
                Property(e => e.url)
                .IsUnicode(false);

          
                HasMany(e => e.exccursiones)
                .WithRequired(e => e.item)
                .HasForeignKey(e => e.item_id)
                .WillCascadeOnDelete(false);
        }
    }
}
