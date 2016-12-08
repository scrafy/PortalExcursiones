using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/puntorecogida")]
    public class PuntoRecogidaController : BaseControllers
    {
        private IOperacionesComunes<puntorecogida> opcomun = null;

        public PuntoRecogidaController(IOperacionesComunes<puntorecogida> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] puntorecogida puntorecogida)
        {
            return opcomun.Crear(puntorecogida, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]puntorecogida puntorecogida)
        {
            return opcomun.Actualizar(puntorecogida, this.ModelState);
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