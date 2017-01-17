using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/grupoedad")]
    public class GrupoEdadController : BaseControllers
    {
        private IOperacionesComunes<grupoedad> opcomun = null;
        private ICreacionMultiple<grupoedad> multiple = null;

        public GrupoEdadController(IOperacionesComunes<grupoedad> _opcomun,ICreacionMultiple<grupoedad> _multiple)
        {
            opcomun = _opcomun;
            multiple = _multiple;
        }
               
        [Route("crearmultiple")]
        [HttpPost]
        [Authorize(Roles="proveedor")]
        public HttpResponseMessage CrearMultiple([FromBody] List<grupoedad> grupoedad)
        {
            return multiple.Crear(grupoedad, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Put([FromBody]grupoedad grupoedad)
        {
            return opcomun.Actualizar(grupoedad, this.ModelState);
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
        
    }
}