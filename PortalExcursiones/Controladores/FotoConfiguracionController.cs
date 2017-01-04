using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/fotoconfiguracion")]
    public class FotoConfiguracionController : BaseControllers
    {
        private IOperacionesComunes<fotoconfiguracion> opcomun;
        private IOperacionesFotoConfiguracion op;

        public FotoConfiguracionController(IOperacionesComunes<fotoconfiguracion> _opcomun, IOperacionesFotoConfiguracion _op)
        {
            this.opcomun = _opcomun;
            this.op = _op;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] fotoconfiguracion fotoconfiguracion)
        {
            return opcomun.Crear(fotoconfiguracion, this.ModelState);
        }

        [Route("{id}")]
        public HttpResponseMessage Delete(long id)
        {
            return op.Eliminar(id);
        }

        [Route]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
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