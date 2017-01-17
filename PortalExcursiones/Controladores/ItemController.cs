using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
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
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Post([FromBody] item item)
        {
            return opcomun.Crear(item, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Put([FromBody]item item)
        {
            return opcomun.Actualizar(item, this.ModelState);
        }

        [Route]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual, regxpag);
        }

        [Route("{id}")]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }

        [Route()]
        [Authorize(Roles = "administrador")]
        public HttpResponseMessage Delete([FromBody]EliminarEntidadModel datos)
        {
            return opcomun.Eliminar(datos.Id);
        }



    }
}