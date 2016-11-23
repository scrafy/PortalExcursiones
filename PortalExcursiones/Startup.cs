using CapaDatos.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using Microsoft.Practices.Unity;

namespace PortalExcursiones
{
    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var container = ResolvedorDependencias.ObtenerContenedor();
            container.RegisterInstance<IDataProtectionProvider>(app.GetDataProtectionProvider());
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
        }
    }

  
}
