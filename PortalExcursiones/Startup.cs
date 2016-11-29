using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using Microsoft.Practices.Unity;
using Microsoft.AspNet.Identity;
using System;

namespace PortalExcursiones
{
    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var container = ResolvedorDependencias.ObtenerContenedor();
            container.RegisterInstance<IDataProtectionProvider>(app.GetDataProtectionProvider());
            app.UseCookieAuthentication(new CookieAuthenticationOptions() {

                 ExpireTimeSpan = TimeSpan.FromMinutes(30),
                 AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
           
        }
    }

  
}
