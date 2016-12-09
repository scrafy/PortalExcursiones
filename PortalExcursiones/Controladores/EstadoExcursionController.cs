using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/estado")]
    public class EstadoExcursionController : BaseControllers
    {
        private IOperacionesComunes<estadoexcursion> opcomun = null;

        public EstadoExcursionController(IOperacionesComunes<estadoexcursion> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] estadoexcursion estadoexcursion)
        {
            return opcomun.Crear(estadoexcursion, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]estadoexcursion estadoexcursion)
        {
            return opcomun.Actualizar(estadoexcursion, this.ModelState);
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