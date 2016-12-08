using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/proveedores")]
    public class ProveedorController : BaseControllers
    {
        private IOperacionesComunes<proveedor> opcomun = null;


        public ProveedorController(IOperacionesComunes<proveedor> _opcomun)
        {
            opcomun = _opcomun;
        }


        [Route]
        public HttpResponseMessage Post([FromBody] proveedor proveedor)
        {
            return opcomun.Crear(proveedor, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([ValueProvider(typeof(ProveedorValorFactory))]  proveedor proveedor)
        {
            return opcomun.Actualizar(proveedor, this.ModelState);
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
