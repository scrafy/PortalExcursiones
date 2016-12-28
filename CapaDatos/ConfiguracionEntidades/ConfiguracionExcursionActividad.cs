using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionExcursionActividad : EntityTypeConfiguration<excursionactividad>
    {
        public ConfiguracionExcursionActividad()
        {
            Property(e => e.queharas)
            .IsUnicode(false);


            Property(e => e.queesperar)
            .IsUnicode(false);


            Property(e => e.noincluye)
            .IsUnicode(false);


            Property(e => e.antesdeir)
            .IsUnicode(false);  

            HasMany(e => e.fechas)
            .WithRequired(e => e.excursionactividad)
            .WillCascadeOnDelete(false); 
         

          
            HasMany(e => e.items)
            .WithRequired(e => e.excursionactividad)
            .WillCascadeOnDelete(false);

          
            HasMany(e => e.precios)
            .WithRequired(e => e.excursionactividad)
            .WillCascadeOnDelete(false);

            HasMany(e => e.idiomas)
           .WithRequired(e => e.excursion_actividad)
           .WillCascadeOnDelete(false);

            HasMany(e => e.puntos_recogida)
           .WithRequired(e => e.excursion_actividad)
           .WillCascadeOnDelete(false);

            HasMany(e => e.grupoedades)
           .WithRequired(e => e.exact)
           .HasForeignKey(e=>e.exact_id)
           .WillCascadeOnDelete(false);

            HasMany(e => e.factura_items)
           .WithRequired(e => e.exact)
           .HasForeignKey(e => e.exact_id)
           .WillCascadeOnDelete(false);

        }
    }
}
