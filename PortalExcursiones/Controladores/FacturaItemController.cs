using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/facturaitem")]
    public class FacturaItemController : BaseControllers
    {
        private IOperacionesComunes<facturaitem> opcomun = null;

        public FacturaItemController(IOperacionesComunes<facturaitem> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] facturaitem facturaitem)
        {
            return opcomun.Crear(facturaitem, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]facturaitem facturaitem)
        {
            return opcomun.Actualizar(facturaitem, this.ModelState);
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

        [Route()]
        public HttpResponseMessage Delete([FromBody]EliminarEntidadModel datos)
        {
            return opcomun.Eliminar(datos.Id);
        }

    }
}