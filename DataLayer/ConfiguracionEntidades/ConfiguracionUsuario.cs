using System.Data.Entity.ModelConfiguration;
using CapaDatos.Entidades;

namespace CapaDatos.ConfiguracionEntidades
{
    public class ConfiguracionUsuario : EntityTypeConfiguration<usuario>
    {
        public ConfiguracionUsuario()
        {
           
              Property(e => e.nombre)
              .IsUnicode(false);

           
                Property(e => e.primerapellido)
                .IsUnicode(false);

           
                Property(e => e.segundoapellido)
                .IsUnicode(false);

           
                Property(e => e.email)
                .IsUnicode(false);

           
                Property(e => e.direccion1)
                .IsUnicode(false);

           
                Property(e => e.direccion2)
                .IsUnicode(false);

           
                Property(e => e.telefono1)
                .IsUnicode(false);

           
                Property(e => e.telefono2)
                .IsUnicode(false);

           
                HasOptional(e => e.cliente)
                .WithRequired(e => e.usuario);

           
                HasOptional(e => e.colaborador)
                .WithRequired(e => e.usuario);

           
                HasOptional(e => e.guia)
                .WithRequired(e => e.usuario);

           
                HasOptional(e => e.proveedor)
                .WithRequired(e => e.usuario);
        }
    }
}
