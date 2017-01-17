using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Infraestructura.ProveedorValor;
using PortalExcursiones.Modelos.ModelosEntrada;


namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : BaseControllers
    {
        private IOperacionesComunes<usuario> opcomun = null;
        private IOperacionesUsuario opusu = null;


        public UsuarioController(IOperacionesComunes<usuario> _opcomun,IOperacionesUsuario _opusu)
        {
            opcomun = _opcomun;
            opusu = _opusu;
        }
        
        [Route]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Post([FromBody] usuario usuario)
        {
            return opcomun.Crear(usuario, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Put([ValueProvider(typeof(ProveedorValorFactory))] usuario usuario)
        {
            return opcomun.Actualizar(usuario, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual, regxpag);
        }

        [Route("{id}")]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public HttpResponseMessage Login([FromBody] LoginModel login)
        {
            return opusu.Login(login,this.ModelState);
        }

        [HttpGet]
        [Route("logout")]
        [AllowAnonymous]
        public HttpResponseMessage Logout()
        {
            return opusu.Logout();
        }

        [HttpPost]
        [Route("cambiarpassword")]
        [Authorize(Roles = "administrador,cliente,proveedor")]
        public HttpResponseMessage CambioPasword(CambioPasswordModel modelo)
        {
            return opusu.CambiarPassword(modelo,this.ModelState);
        }

       /* [HttpGet]
        [Route("tokenrenovacionpassword")]
        public HttpResponseMessage TokenRenovacionPassword([FromUri]string email)
        {
           return opusu.ObtenerTokenReseteoPassword(email);
        }*/
    
         [HttpGet]
         [Route("resetpassword")]
         [AllowAnonymous]
         public HttpResponseMessage ResetPassword([FromUri] string email)
         {
             return opusu.ResetPassword(email);
         }

      

        [HttpGet]
        [Route("cambiaridioma/{idioma}")]
        [AllowAnonymous]
        public HttpResponseMessage CambiarIdioma(string idioma)
        {
            return opusu.CambiarIdioma(idioma);
        }

        [HttpPost]
        [Route("anadirole")]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage AnadirRole([FromBody] RolModel datos)
        {
            return opusu.AnadirRol(datos);
        }

        [HttpPost]
        [Route("eliminarole")]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage EliminarRole([FromBody] RolModel datos)
        {
            return opusu.EliminarRol(datos);
        }

    }
}
