﻿using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/preciotemporada")]
    public class PrecioTemporadaController : BaseControllers
    {
        private IOperacionesComunes<preciotemporada> opcomun = null;

        public PrecioTemporadaController(IOperacionesComunes<preciotemporada> _opcomun)
        {
            opcomun = _opcomun;
        }

        [Route]
        public HttpResponseMessage Post([FromBody] preciotemporada preciotemporada)
        {
            return opcomun.Crear(preciotemporada, this.ModelState);
        }

        [Route]
        public HttpResponseMessage Put([FromBody]preciotemporada preciotemporada)
        {
            return opcomun.Actualizar(preciotemporada, this.ModelState);
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