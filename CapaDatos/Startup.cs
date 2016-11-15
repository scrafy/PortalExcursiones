using CapaDatos.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace CapaDatos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(Contexto.Crear);
            app.CreatePerOwinContext<AdministradorUsuario>(AdministradorUsuario.Crear);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
        }
    }
}
