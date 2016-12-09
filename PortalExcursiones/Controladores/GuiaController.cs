using System.Web.Http;
using CapaDatos.Entidades;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Web.Http.ValueProviders;
using PortalExcursiones.Infraestructura.ProveedorValor;
using PortalExcursiones.Modelos.ModelosEntrada;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/guia")]
    public class GuiaController : BaseControllers
    {
        private IOperacionesComunes<guia> opcomun = null;
        private IOperacionesGuia op = null;

        public GuiaController(IOperacionesComunes<guia> _opcomun,IOperacionesGuia _op)
        {
            opcomun = _opcomun;
            op = _op;
        }


        [Route]
        public HttpResponseMessage Post([FromBody] guia guia)
        {
            return opcomun.Crear(guia, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([ValueProvider(typeof(ProveedorValorFactory))]  guia guia)
        {
            return opcomun.Actualizar(guia, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Get()
        {
            return opcomun.Todos();
        }

        [Route("anadiridioma")]
        [HttpPost]
        public HttpResponseMessage AnadirIdioma([FromBody] AnadirEliminarIdiomaModel datos)
        {
            return op.AnadirIdioma(datos.Idioma_id, datos.Guia_id);
        }

        [Route("eliminaridioma")]
        [HttpDelete]
        public HttpResponseMessage EliminarIdioma([FromBody] AnadirEliminarIdiomaModel datos)
        {
            return op.EliminarIdioma(datos.Idioma_id, datos.Guia_id);
        }




    }
}
