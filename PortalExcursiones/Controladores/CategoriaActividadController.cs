using PortalExcursiones.Infraestructura.Interfaces;
using CapaDatos.Entidades;
using System.Net.Http;
using System.Web.Http;


namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/categoriaactividad")]
    public class CategoriaActividadController : BaseControllers
    {
        private IOperacionesComunes<categoriactividad> opcomun = null;

        public CategoriaActividadController(IOperacionesComunes<categoriactividad> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] categoriactividad categoriactividad)
        {
            return opcomun.Crear(categoriactividad, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]categoriactividad categoriactividad)
        {
            return opcomun.Actualizar(categoriactividad, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Get(int pag_actual = 1,int regxpag = 10)
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

    