using Microsoft.AspNet.Identity;
using CapaDatos.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;


namespace CapaDatos.Identity
{
    public class AdministradorUsuario : UserManager<usuario>
    {
       
        public AdministradorUsuario(IUserStore<usuario> almacen)
        : base(almacen)
        {

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
