using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/informe")]
    public class ConsultaController : BaseControllers
    {
        private IGeneracionInformes inf = null;
       
        public ConsultaController(IGeneracionInformes _inf)
        {
            inf = _inf;
        }

        [Route("reservas")]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Post([FromBody] ClientesReserva fechas,int pag_actual = 1,int regxpag = 10)
        {
            return inf.Reservas(fechas, ModelState,pag_actual, regxpag);
        }
    }
}