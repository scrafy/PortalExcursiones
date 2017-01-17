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
        [Authorize(Roles="proveedor")]
        public HttpResponseMessage Post([FromBody] facturaitem facturaitem)
        {
            return opcomun.Crear(facturaitem, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Put([FromBody]facturaitem facturaitem)
        {
            return opcomun.Actualizar(facturaitem, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual,regxpag);
        }

        [Route("{id}")]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }

        [Route()]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Delete([FromBody]EliminarEntidadModel datos)
        {
            return opcomun.Eliminar(datos.Id);
        }

    }
}