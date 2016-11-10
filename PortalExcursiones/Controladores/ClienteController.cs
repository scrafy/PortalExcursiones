using System.Web.Http;
using CapaDatos.Entidades;
using System.Web.Http.Results;
using System;
using System.Web.Http.ModelBinding;
using PortalExcursiones.Modelos.ModelosSalida.Errores;
using System.Net.Http;
using System.Text;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;


namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/clients")]
    public class ClienteController : BaseController
    {

        //Obtiene un listado de todos los clientes registrados en la base de datos 
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Registro([FromBody] cliente cliente)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    context.usuario.Add(cliente.usuario);
                    context.SaveChanges();
                    context.cliente.Add(cliente);
                    context.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                }
                else
                {
                    return this.ObjectoRespuesta(HttpStatusCode.BadRequest,new ErrorValidacionFormulario(ModelState));
                }
            }
            catch(Exception ex)
            {
                return this.ObjectoRespuesta(HttpStatusCode.InternalServerError,new ErrorGenerico(ex));
            }
        }


        [Route("all")]
        [HttpGet]
        public HttpResponseMessage All()
        {
            try
            {
                var clientes = context.usuario.Select(x => new
                {
                    id = x.id,
                    numeroidentificacion = x.cliente.numidentificacion,
                    infadicional = x.cliente.infadicional,
                    direccion1 = x.direccion1,
                    direccion2 = x.direccion2,
                    email = x.email,
                    telefono1 = x.telefono1,
                    telefono2 = x.telefono2,
                    nombre = x.nombre,
                    primerapellido = x.primerapellido,
                    segundopellido = x.segundoapellido,
                    localidad =  x.localidad

                }).ToList();
            

                return this.ObjectoRespuesta(HttpStatusCode.OK, clientes);
            }
            catch(Exception ex)
            {
                return this.ObjectoRespuesta(HttpStatusCode.InternalServerError, new ErrorGenerico(ex));
            }
        }
    }
}
