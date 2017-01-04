using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/puntorecogida")]
    public class PuntoRecogidaController : BaseControllers
    {
        private IOperacionesPuntoRecogida op = null;


        public PuntoRecogidaController(IOperacionesPuntoRecogida _op)
        {
            op = _op;

        }

        [Route]
        public HttpResponseMessage Post([FromBody] PuntoRecogidaModel puntorecogida)
        {
            return op.Crear(puntorecogida, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]PuntoRecogidaModel puntorecogida)
        {
            return op.Actualizar(puntorecogida, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Get(int pag_actual = 1,int regxpag = 10)
        {
            return op.Todos(pag_actual, regxpag);
        }

        [Route("{id}")]
        public HttpResponseMessage Get(long id)
        {
            return op.BusquedaPorId(id);
        }

        [Route("busquedapuntosexact/{id}")]
        [HttpGet]
        public HttpResponseMessage BusquedaExact(long id)
        {
            return op.BusquedaPorExAct(id);
        }

        [Route()]
        public HttpResponseMessage Delete([FromBody]PuntoRecogidaEliminarModel datos)
        {
            return op.Eliminar(datos.Id);
        }
    }
}