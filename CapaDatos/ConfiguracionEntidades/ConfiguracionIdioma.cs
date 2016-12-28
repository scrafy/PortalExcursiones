using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionIdioma : EntityTypeConfiguration<idioma>
    {
        public ConfiguracionIdioma()
        {
           
              Property(e => e.lenguage)
              .IsUnicode(false);

          
                HasMany(e => e.idiomas)
                .WithRequired(e => e.idioma)
                .HasForeignKey(e => e.idioma_id)
                .WillCascadeOnDelete(false);

        }
    }
}

