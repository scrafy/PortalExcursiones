using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/idioma")]
    public class IdiomaController : BaseControllers
    {
        private IOperacionesComunes<idioma> opcomun = null;

        public IdiomaController(IOperacionesComunes<idioma> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Get()
        {
            return opcomun.Todos();
        }

      



    }
}