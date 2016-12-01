using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/guias")]
    public class GuiaController : BaseController
    {
        private IOperacionesComunes<guia> opcomun = null;


        public GuiaController(IOperacionesComunes<guia> _opcomun)
        {
            opcomun = _opcomun;
        }


        [Route]
        public HttpResponseMessage Post([FromBody] guia guia)
        {
            return opcomun.Crear(guia, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([ValueProvider(typeof(ProveedorValorUsuarioFactory))]  guia guia)
        {
            return opcomun.Actualizar(guia, this.ModelState);
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
