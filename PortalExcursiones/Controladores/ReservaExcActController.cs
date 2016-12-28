using System.Web.Http;
using System.Net.Http;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Web.Http.ModelBinding;
using PortalExcursiones.Infraestructura.ProveedorValor;
using System.Web.Http.ValueProviders;
using System;
namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/reservaexact")]
    public class ReservaExcActController : BaseControllers
    {
        private IOperacionesComunes<ReservaExcursionActividadModel> opcomun = null;


        public ReservaExcActController(IOperacionesComunes<ReservaExcursionActividadModel> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody]ReservaExcursionActividadModel reservaexact)
        {
            return opcomun.Crear(reservaexact, this.ModelState);
        }
    }
}