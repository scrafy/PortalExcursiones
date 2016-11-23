using System.Web.Http;
using CapaDatos.Entidades;
using Microsoft.AspNet.Identity;
using CapaDatos.Identity;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Net.Http;
using System;
using CapaDatos;
using PortalExcursiones.Controladores.ImplementacionInterfaces;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using PortalExcursiones.Controladores.Interfaces;

namespace PortalExcursiones.Controladores
{
    [RoutePrefix("api/clientes")]
    public class ClienteController : BaseController
    {
        private IOperacionesComunes<cliente> servicios = null;


        public ClienteController(IOperacionesComunes<cliente> _servicios)
        {
             servicios = _servicios;
        }
        

        [Route]
        public HttpResponseMessage Post([FromBody] cliente cliente)
        {
            return servicios.Crear(cliente);
        }

       

        //[Route]
        //public HttpResponseMessage Post([FromBody] cliente cliente)
        //{
        //    try
        //    {
        //        if(ModelState.IsValid)
        //        {
        //            context.usuario.Add(cliente.usuario);
        //            context.SaveChanges();
        //            context.cliente.Add(cliente);
        //            context.SaveChanges();
        //            return this.ObjectoRespuesta(Codigos.OK, null, null, null,null);
        //        }
        //        else
        //        {
        //            return this.ObjectoRespuesta(Codigos.ERROR_DE_VALIDACION, null, null, null, ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.ObjectoRespuesta(Codigos.ERROR_DE_SERVIDOR, null, ex, null, null);
        //    }
        //}

        //[Route]
        //public HttpResponseMessage Put([FromBody] cliente cliente)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            cliente aux = context.cliente.Find(cliente.usuario_id);
        //            if (aux != null)
        //            {
        //                context.Entry(aux).State = EntityState.Detached;
        //                cliente.usuario.id = cliente.usuario_id;
        //                context.Entry(cliente).State = EntityState.Modified;
        //                context.Entry(cliente.usuario).State = EntityState.Modified;
        //                context.SaveChanges();
        //                return this.ObjectoRespuesta(Codigos.OK, null, null, null, null);
        //            }
        //            else
        //            {
        //                return this.ObjectoRespuesta(Codigos.REGISTRO_NO_ENCONTRADO,null, null,Errores.error1, ModelState);
        //            }
        //        }
        //        else
        //        {
        //            return this.ObjectoRespuesta(Codigos.ERROR_DE_VALIDACION, null, null, null, ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.ObjectoRespuesta(Codigos.ERROR_DE_SERVIDOR, null, ex, null, null);
        //    }
        //}

        //[Route]
        //public HttpResponseMessage Get()
        //{
        //    try
        //    {
        //        var query = context.cliente.Select(x => new
        //        {
        //            id = x.usuario_id,
        //            numero_identificacion = x.numidentificacion,
        //            inf_adicional = x.infadicional,
        //            direccion1 = x.usuario.direccion1,
        //            direccion2 = x.usuario.direccion2,
        //            email = x.usuario.email,
        //            telefono1 = x.usuario.telefono1,
        //            telefono2 = x.usuario.telefono2,
        //            nombre = x.usuario.nombre,
        //            primerapellido = x.usuario.primerapellido,
        //            segundopellido = x.usuario.segundoapellido,
        //            localidad = x.usuario.localidad.nombre,
        //            codigo_postal = x.usuario.localidad.cp,
        //            provincia = x.usuario.localidad.provincia.nombre,
        //            pais = x.usuario.localidad.provincia.pais.nombre

        //        });

        //        var clientes = query.ToList();

        //        return this.ObjectoRespuesta(Codigos.OK,clientes, null, null, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.ObjectoRespuesta(Codigos.ERROR_DE_SERVIDOR, null, ex, null, null);
        //    }
        //}

        //[Route("{id}")]
        //public HttpResponseMessage Get(int id)
        //{
        //    try
        //    {
        //        var cliente = context.cliente.Include("usuario").Where(x => x.usuario_id == id).Select(x => new
        //        {
        //            id = x.usuario_id,
        //            numero_identificacion = x.numidentificacion,
        //            inf_adicional = x.infadicional,
        //            direccion1 = x.usuario.direccion1,
        //            direccion2 = x.usuario.direccion2,
        //            email = x.usuario.email,
        //            telefono1 = x.usuario.telefono1,
        //            telefono2 = x.usuario.telefono2,
        //            nombre = x.usuario.nombre,
        //            primerapellido = x.usuario.primerapellido,
        //            segundopellido = x.usuario.segundoapellido,
        //            localidad = x.usuario.localidad.nombre,
        //            codigo_postal = x.usuario.localidad.cp,
        //            provincia = x.usuario.localidad.provincia.nombre,
        //            pais = x.usuario.localidad.provincia.pais.nombre
        //        }).FirstOrDefault();
        //        if (cliente != null)
        //        {
        //            return this.ObjectoRespuesta(Codigos.OK, cliente, null, null, null, null);
        //        }
        //        else
        //        {
        //            return this.ObjectoRespuesta(Codigos.REGISTRO_NO_ENCONTRADO, null, null, Errores.error1, ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.ObjectoRespuesta(Codigos.ERROR_DE_SERVIDOR, null, ex, null, null);
        //    }
        //}

    }
}
