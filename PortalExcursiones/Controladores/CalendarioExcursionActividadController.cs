using System.Web.Http;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/calendario")]
    public class CalendarioExcursionActividadController : BaseController
    {
        private IOperacionesCalendarioExcursionActividad op = null;


        public CalendarioExcursionActividadController(IOperacionesCalendarioExcursionActividad _op)
        {
            op = _op;
        }

        [Route]
        public HttpResponseMessage Post([ValueProvider(typeof(ProveedorValorCalendarioExcursionActividadFactory))] CalendarioExcursionModel datos)
        {
            return op.Crear(datos, this.ModelState);
        }
    }
}