using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionLocalidad : EntityTypeConfiguration<localidad>
    {
        public ConfiguracionLocalidad()
        {
           
              Property(e => e.nombre)
              .IsUnicode(false);

           
                HasMany(e => e.puntosrecogida)
                .WithRequired(e => e.localidad)
                .HasForeignKey(e => e.localidad_id)
                .WillCascadeOnDelete(false);

           
                HasMany(e => e.recogidasdevoluciones)
                .WithRequired(e => e.localidad)
                .HasForeignKey(e => e.localidad_id)
                .WillCascadeOnDelete(false);

            
                HasMany(e => e.reservas)
                .WithOptional(e => e.localidad)
                .HasForeignKey(e => e.localidad_id)
                .WillCascadeOnDelete(false);

                HasMany(e => e.usuarios)
                .WithRequired(e => e.localidad)
                .HasForeignKey(e => e.localidad_id)
                .WillCascadeOnDelete(false);
        }
    }
}
