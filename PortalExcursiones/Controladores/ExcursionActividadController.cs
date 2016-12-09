using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;
using PortalExcursiones.Modelos.ModelosEntrada;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/excursionactividad")]
    public class ExcursionActividadController : BaseControllers
    {
        private IOperacionesComunes<excursionactividad> opcomun = null;
        private IOperacionesExcursionActividad op = null;


        public ExcursionActividadController(IOperacionesComunes<excursionactividad> _opcomun,IOperacionesExcursionActividad _op)
        {
            opcomun = _opcomun;
            op = _op;
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

        [Route("anadiritem")]
        [HttpPost]
        public HttpResponseMessage AnadirItem([FromBody]AnadirEliminarItemModel datos)
        {
            return op.AnadirItem(datos.Item_id, datos.Exact_id);
        }

        [Route("eliminaritem")]
        [HttpDelete]
        public HttpResponseMessage EliminarItem([FromBody]AnadirEliminarItemModel datos)
        {
            return op.EliminarItem(datos.Item_id, datos.Exact_id);
        }
    }
}