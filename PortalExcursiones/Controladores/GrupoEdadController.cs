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

        [Route]
        public HttpResponseMessage Post([FromBody] grupoedad grupoedad)
        {
            return opcomun.Crear(grupoedad, this.ModelState);
        }

        [Route("crearmultiple")]
        [HttpPost]
        public HttpResponseMessage CrearMultiple([FromBody] List<grupoedad> grupoedad)
        {
            return multiple.Crear(grupoedad, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]grupoedad grupoedad)
        {
            return opcomun.Actualizar(grupoedad, this.ModelState);
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