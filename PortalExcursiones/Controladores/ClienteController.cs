using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : BaseControllers
    {
        private IOperacionesComunes<cliente> opcomun = null;


        public ClienteController(IOperacionesComunes<cliente> _opcomun)
        {
            opcomun = _opcomun;
        }


        [Route]
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] cliente cliente)
        {
            return opcomun.Crear(cliente, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "cliente")]
        public HttpResponseMessage Put([ValueProvider(typeof(ProveedorValorFactory))]  cliente cliente)
        {
            return opcomun.Actualizar(cliente, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual, regxpag);
        }

        [Route("{id}")]
        [Authorize(Roles = "cliente")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }
    }
}
