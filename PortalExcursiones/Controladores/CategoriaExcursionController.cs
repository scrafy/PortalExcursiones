using System.Web.Http;
using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/categoriaexcursion")]
    public class CategoriaExcursionController : BaseControllers
    {
        private IOperacionesComunes<categoriaexcursion> opcomun = null;

        public CategoriaExcursionController(IOperacionesComunes<categoriaexcursion> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] categoriaexcursion categoriaexcursion)
        {
            return opcomun.Crear(categoriaexcursion, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]categoriaexcursion categoriaexcursion)
        {
            return opcomun.Actualizar(categoriaexcursion, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual,regxpag);
        }

        [Route("{id}")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }
    }
}

