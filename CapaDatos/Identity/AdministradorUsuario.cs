using Microsoft.AspNet.Identity;
using CapaDatos.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;

namespace CapaDatos.Identity
{
    public class AdministradorUsuario : UserManager<usuario>
    {
       
        public AdministradorUsuario(IUserStore<usuario> almacen)
        : base(almacen)
        {
            UserValidator = new ValidadorUsuario(this);
            PasswordValidator = new ValidadorPassword();
        }
        

        public void SetDataProtectionProvider(IDataProtectionProvider p)
        {
            if(p!=null)
            {
                var  t = this;
                IDataProtector dataProtector = p.Create("ASP.NET Identity");
                t.UserTokenProvider = new DataProtectorTokenProvider<usuario>(dataProtector);
            }
        }

        

    }
}
