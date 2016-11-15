using Microsoft.AspNet.Identity;
using CapaDatos.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace CapaDatos.Identity
{
    public class AdministradorUsuario : UserManager<usuario>
    {
        public AdministradorUsuario(IUserStore<usuario> almacen)
        : base(almacen)
        {
           
        }

        public static AdministradorUsuario Crear(IdentityFactoryOptions<AdministradorUsuario> opciones, IOwinContext contexto)
        {
            var administrador = new AdministradorUsuario(new UserStore<usuario>(contexto.Get<Contexto>()));
            administrador.UserValidator = new UserValidator<usuario>(administrador)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
                
            };


            administrador.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            return administrador;
        }

    }
}
