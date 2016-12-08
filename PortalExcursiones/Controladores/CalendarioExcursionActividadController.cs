using System.Web.Http;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Web.Http.ModelBinding;
using PortalExcursiones.Infraestructura.ProveedorValor;
using System.Web.Http.ValueProviders;
using System;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/calendario")]
    public class CalendarioExcursionActividadController : BaseControllers
    {
        private IOperacionesCalendarioExcursionActividad op = null;


        public CalendarioExcursionActividadController(IOperacionesCalendarioExcursionActividad _op)
        {
            op = _op;
           
        }

        [Route]
        public HttpResponseMessage Post(/*[ValueProvider(typeof(ProveedorValorFactory))]*/CalendarioExcursionModel calendarioexcursion)
        {
            return op.Crear(calendarioexcursion, this.ModelState);
        }

        [Route("{fecha}/{exact_id}")]
        public HttpResponseMessage Get(DateTime fecha,long exact_id)
        {
            return op.Eliminar(fecha, exact_id);
        }

        [Route("{fecha}/{fechanueva}/{exact_id}")]
        public HttpResponseMessage Get(DateTime fecha, DateTime fechanueva, long exact_id)
        {
            return op.Actualizar(fecha,fechanueva,exact_id);
        }
    }
}