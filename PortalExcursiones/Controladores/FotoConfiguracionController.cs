using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
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
       

        public FotoConfiguracionController(IOperacionesComunes<fotoconfiguracion> _opcomun)
        {
            this.opcomun = _opcomun;
         
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Post([FromBody] fotoconfiguracion fotoconfiguracion)
        {
            return opcomun.Crear(fotoconfiguracion, this.ModelState);
        }

        [Route()]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Delete([FromBody] EliminarEntidadModel datos)
        {
            return opcomun.Eliminar(datos.Id);
        }

        [Route]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Get(int pag_actual = 1, int regxpag = 10)
        {
            return opcomun.Todos(pag_actual, regxpag);
        }

        [Route("{id}")]
        [Authorize(Roles = "proveedor")]
        public HttpResponseMessage Get(string id)
        {
            return opcomun.BusquedaPorId(id);
        }


    }
}