using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/clientes")]
    public class ClienteController : BaseController
    {
        private IOperacionesComunes<cliente> opcomun = null;


        public ClienteController(IOperacionesComunes<cliente> _opcomun)
        {
            opcomun = _opcomun;
        }


        [Route]
        public HttpResponseMessage Post([FromBody] cliente cliente)
        {
            return opcomun.Crear(cliente, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([ValueProvider(typeof(ProveedorValorUsuarioFactory))]  cliente cliente)
        {
            return opcomun.Actualizar(cliente, this.ModelState);
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




    }
}
