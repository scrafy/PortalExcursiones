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
        public HttpResponseMessage Post([FromBody]CalendarioExcursionModel calendarioexcursion)
        {
            return op.Crear(calendarioexcursion, this.ModelState);
        }

        [Route()]
        public HttpResponseMessage Delete([FromBody]CalendarioExcursionActualizarEliminarModel datos)
        {
            return op.Eliminar(datos,this.ModelState);
        }

        [Route()]
        public HttpResponseMessage Put([FromBody]CalendarioExcursionActualizarEliminarModel datos)
        {
            return op.Actualizar(datos,this.ModelState);
        }
       
    }
}