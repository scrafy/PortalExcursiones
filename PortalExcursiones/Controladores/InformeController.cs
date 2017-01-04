using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/informe")]
    public class InformeController : BaseControllers
    {
        private IGeneracionInformes inf = null;
       
        public InformeController(IGeneracionInformes _inf)
        {
            inf = _inf;
        }

        [Route("reservas")]
        public HttpResponseMessage Post([FromBody] ClientesReserva fechas,[FromUri]int pag_actual = 1,int regxpag = 10)
        {
            return inf.Reservas(fechas, ModelState,pag_actual, regxpag);
        }
    }
}