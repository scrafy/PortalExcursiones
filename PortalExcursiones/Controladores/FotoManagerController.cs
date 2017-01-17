using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{

    [RoutePrefix("api/fotomanager")]
    public class FotoManagerController : BaseControllers
    {
        private IOperacionesFotos op;

        public FotoManagerController(IOperacionesFotos _op)
        {
            this.op = _op;
        }
        [AllowAnonymous]
        public HttpResponseMessage Post()
        {
            return op.Subir(this.Request);           
        }
    }
}