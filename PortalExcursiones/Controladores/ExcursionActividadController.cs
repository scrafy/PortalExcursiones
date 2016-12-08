using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/excursionactividad")]
    public class ExcursionActividadController : BaseControllers
    {
        private IOperacionesComunes<excursionactividad> opcomun = null;


        public ExcursionActividadController(IOperacionesComunes<excursionactividad> _opcomun)
        {
            opcomun = _opcomun;
        }


        [Route]
        public HttpResponseMessage Post([FromBody] excursionactividad excursionactividad)
        {
            return opcomun.Crear(excursionactividad, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody] excursionactividad excursionactividad)
        {
            return opcomun.Actualizar(excursionactividad, this.ModelState);
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