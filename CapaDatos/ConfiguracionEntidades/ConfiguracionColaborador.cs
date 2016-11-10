using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;


namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionColaborador : EntityTypeConfiguration<colaborador>
    {
        public ConfiguracionColaborador()
        {
           
               Property(e => e.nombreempresa)
               .IsUnicode(false);

           
                Property(e => e.cif)
                .IsUnicode(false);

            
                Property(e => e.lat)
                .IsUnicode(false);

            
                Property(e => e.lng)
                .IsUnicode(false);

           
                Property(e => e.observaciones)
                .IsUnicode(false);

           
                HasMany(e => e.reservas)
                .WithOptional(e => e.colaborador)
                .HasForeignKey(e => e.colaborador_id);

        }
    }
}
