using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionGuia : EntityTypeConfiguration<guia>
    {
        public ConfiguracionGuia()
        {
           
               Property(e => e.nota)
               .IsUnicode(false);

           
                HasMany(e => e.excursiones)
                .WithRequired(e => e.guia)
                .HasForeignKey(e => e.guia_id)
                .WillCascadeOnDelete(false);

           
                HasMany(e => e.guias)
                .WithRequired(e => e.guia)
                .HasForeignKey(e => e.guia_id)
                .WillCascadeOnDelete(false);
        }
    }
}

