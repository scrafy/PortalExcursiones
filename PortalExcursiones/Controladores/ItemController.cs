using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/item")]
    public class ItemController : BaseControllers
    {
        private IOperacionesComunes<item> opcomun = null;

        public ItemController(IOperacionesComunes<item> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] item item)
        {
            return opcomun.Crear(item, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]item item)
        {
            return opcomun.Actualizar(item, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual, regxpag);
        }

        [Route("{id}")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }



    }
}