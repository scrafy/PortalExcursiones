using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Collections.Generic;

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
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Post([FromBody] excursionactividad excursionactividad)
        {
            return opcomun.Crear(excursionactividad, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Put([FromBody] excursionactividad excursionactividad)
        {
            return opcomun.Actualizar(excursionactividad, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual, regxpag);
        }

        [Route("{id}")]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }

        [Route("anadiritem")]
        [HttpPost]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage AnadirItem([FromBody]AnadirEliminarItemModel datos)
        {
            return op.AnadirItem(datos.Item_id, datos.Exact_id);
        }

        [Route("eliminaritem")]
        [HttpDelete]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage EliminarItem([FromBody]AnadirEliminarItemModel datos)
        {
            return op.EliminarItem(datos.Item_id, datos.Exact_id);
        }

        [Route("anadiridioma")]
        [HttpPost]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage AnadirIdioma([FromBody]List<IdiomaExActModel> idiomas)
        {
            return op.AnadirIdioma(idiomas);
        }

        [Route("eliminaridioma")]
        [HttpDelete]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage EliminarIdioma([FromBody]IdiomaExActModel datos)
        {
            return op.EliminarIdioma(datos.Idioma_id, datos.Exact_id);
        }

        [Route("anadiritemfactura")]
        [HttpPost]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage AnadirItemFactura([FromBody]List<FacturaItemModel> items)
        {
            return op.AnadirItemFactura(items);
        }

        [Route("eliminaritemfactura")]
        [HttpDelete]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage EliminarItemFactura([FromBody]FacturaItemModel datos)
        {
            return op.EliminarItemFactura(datos.Item_id, datos.Exact_id);
        }

        [Route("anadirpunto")]
        [HttpDelete]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage AnadirPunto([FromBody]List<PuntoModel> puntos)
        {
            return op.AnadirPunto(puntos);
        }

        [Route("eliminarpunto")]
        [HttpDelete]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage EliminarPunto([FromBody]PuntoModel punto)
        {
            return op.EliminarPunto(punto);
        }

        [Route("grupoedad/{exact_id}")]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage GetGrupoEdad(long exact_id)
        {
            return op.GrupoEdad(exact_id);
        }
    }
}