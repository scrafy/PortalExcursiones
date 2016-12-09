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
            return op.Eliminar(datos.Fecha, datos.Exact_id);
        }

        [Route()]
        public HttpResponseMessage Put([FromBody]CalendarioExcursionActualizarEliminarModel datos)
        {
            return op.Actualizar(datos.Fecha,datos.Fechanueva,datos.Exact_id);
        }

        [Route("anadirguiaexcursion")]
        [HttpPost]
        public HttpResponseMessage AnadirGuiaFecha([FromBody]GuiaFechaModel guia)
        {
            return op.AnadirGuia(guia.Fecha,guia.Exact_id, guia.Guia_id);
        }

        [Route("eliminarguiaexcursion")]
        [HttpDelete]
        public HttpResponseMessage EliminarGuiaFecha([FromBody]GuiaFechaModel guia)
        {
            return op.EliminarGuia(guia.Fecha, guia.Exact_id, guia.Guia_id);
        }

        [Route("anadirpuntoexcursion")]
        [HttpPost]
        public HttpResponseMessage AnadirPuntoRecogidaFecha([FromBody]PuntoRecogidaFechaModel punto)
        {
            return op.AnadirPuntoRecogida(punto.Fecha, punto.Exact_id, punto.Punto_id);
        }

        [Route("eliminarpuntoexcursion")]
        [HttpDelete]
        public HttpResponseMessage EliminarPuntoRecogidaFecha([FromBody]PuntoRecogidaFechaModel punto)
        {
            return op.EliminarPuntoRecogida(punto.Fecha, punto.Exact_id, punto.Punto_id);
        }
    }
}