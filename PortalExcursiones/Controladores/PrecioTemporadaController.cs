using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;
using PortalExcursiones.Infraestructura.ProveedorValor;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Modelos.ModelosEntrada;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/preciotemporada")]
    public class PrecioTemporadaController : BaseControllers
    {
        private IOperacionesComunes<preciotemporada> opcomun = null;

        public PrecioTemporadaController(IOperacionesComunes<preciotemporada> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Post([FromBody] preciotemporada preciotemporada)
        {
            return opcomun.Crear(preciotemporada, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Put([FromBody]preciotemporada preciotemporada)
        {
            return opcomun.Actualizar(preciotemporada, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Get(int pag_actual=1,int regxpag = 10)
        {
            return opcomun.Todos(pag_actual, regxpag);
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