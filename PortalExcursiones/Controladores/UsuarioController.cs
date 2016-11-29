using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Infraestructura.ProveedorValor;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.ComponentModel.DataAnnotations;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/usuarios")]
    public class UsuarioController : BaseController
    {
        private IOperacionesComunes<usuario> opcomun = null;
        private IOperacionesUsuario opusu = null;


        public UsuarioController(IOperacionesComunes<usuario> _opcomun,IOperacionesUsuario _opusu)
        {
            opcomun = _opcomun;
            opusu = _opusu;
        }
        
        [Route]
        public HttpResponseMessage Post([FromBody] usuario usuario)
        {
            return opcomun.Crear(usuario, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([ValueProvider(typeof(ProveedorValorUsuarioFactory))] usuario usuario)
        {
            return opcomun.Actualizar(usuario, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Get()
        {
            return opcomun.Todos();
        }

        [Route("{id}")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login([FromBody] LoginModel login)
        {
            return opusu.Login(login,this.ModelState);
        }

        [HttpGet]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            return opusu.Logout();
        }

        [HttpPost]
        [Route("cambiarpassword")]
        public HttpResponseMessage CambioPasword(CambioPasswordModel modelo)
        {
            return opusu.CambiarPassword(modelo,this.ModelState);
        }

        [HttpGet]
        [Route("tokenrenovacionpassword")]
        public HttpResponseMessage TokenRenovacionPassword([FromUri]string email)
        {
           return opusu.ObtenerTokenReseteoPassword(email);
        }

        [HttpPost]
        [Route("renovarpassword")]
        public HttpResponseMessage RenovarPassword([FromBody] RenovacionPasswordModel datos)
        {
            return opusu.RenovarPassword(datos,this.ModelState);
        }



    }
}
