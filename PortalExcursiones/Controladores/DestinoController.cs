﻿using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/destino")]
    public class DestinoController : BaseControllers
    {
        private IOperacionesComunes<destino> opcomun = null;

        public DestinoController(IOperacionesComunes<destino> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] destino destino)
        {
            return opcomun.Crear(destino, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]destino destino)
        {
            return opcomun.Actualizar(destino, this.ModelState);
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