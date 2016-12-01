using CapaDatos.Entidades;
using System;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using CapaDatos.Identity;
using CapaDatos;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Linq;
using PortalExcursiones.Modelos.ModelosEntrada;
using PortalExcursiones.Properties;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class UsuarioOperacionesComunes : IOperacionesComunes<usuario>
    {
        private AdministradorUsuario mgr = null;
        private Contexto contexto = null;
        private Respuesta resp = null;

        public UsuarioOperacionesComunes(AdministradorUsuario _mgr, Contexto _contexto, Respuesta _resp)
        {
            mgr = _mgr;
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Crear(usuario Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    IdentityResult result = mgr.Create(Entidad, Entidad.PasswordHash);
                    if(!result.Succeeded)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = result.Errors;
                        return resp.ObjectoRespuesta();
                    }
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    return resp.ObjectoRespuesta();
                }
                else
                {
                    resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                    resp.Objetoerror = modelo;
                    return resp.ObjectoRespuesta();
                }
            }
            catch (Exception ex)
            {
                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
        }

        public HttpResponseMessage Actualizar(usuario Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    var aux = mgr.FindById(Entidad.Id);
                    if(aux == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = String.Format(Errores.error1,Entidad.Id);
                        return resp.ObjectoRespuesta();
                    }
                    Entidad.PasswordHash = aux.PasswordHash;
                    Entidad.EmailConfirmed = aux.EmailConfirmed;
                    Entidad.SecurityStamp = aux.SecurityStamp;
                    Entidad.PhoneNumberConfirmed = aux.PhoneNumberConfirmed;
                    Entidad.TwoFactorEnabled = aux.TwoFactorEnabled;
                    Entidad.LockoutEnabled = aux.LockoutEnabled;
                    Entidad.LockoutEndDateUtc = aux.LockoutEndDateUtc;
                    Entidad.AccessFailedCount = aux.AccessFailedCount;
                    contexto.Entry(aux).State = EntityState.Detached;
                    contexto.Entry(Entidad).State = EntityState.Modified;
                    IdentityResult result = mgr.Update(Entidad);
                  
                    if(!result.Succeeded)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = result.Errors;
                        return resp.ObjectoRespuesta();
                    }
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    return resp.ObjectoRespuesta();
                }
                else
                {
                    resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                    resp.Objetoerror = modelo;
                    return resp.ObjectoRespuesta();
                }
            }
            catch (Exception ex)
            {
                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
        }

        public HttpResponseMessage BusquedaPorId(string id)
        {
            try
            {
                var usuario = mgr.Users.Where(e => e.Id == id).Select(e => new
                {

                    id = e.Id,
                    direccion1 = e.direccion1,
                    direccion2 = e.direccion2,
                    email = e.Email,
                    telefono = e.PhoneNumber,
                    nombre = e.nombre,
                    primerapellido = e.primerapellido,
                    segundopellido = e.segundoapellido,
                    localidad = e.localidad.nombre,
                    codigo_postal = e.localidad.cp,
                    provincia = e.localidad.provincia.nombre,
                    pais = e.localidad.provincia.pais.nombre
                }).FirstOrDefault();

                if (usuario == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    resp.Mensaje_error = String.Format(Errores.error1, id);
                    return resp.ObjectoRespuesta();
                }
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = usuario;
                return resp.ObjectoRespuesta();

            }
            catch (Exception ex)
            {
                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
        }

        public HttpResponseMessage Todos()
        {
            try
            {
                var usuarios = mgr.Users.Select(e => new
                {

                    id = e.Id,
                    direccion1 = e.direccion1,
                    direccion2 = e.direccion2,
                    email = e.Email,
                    telefono = e.PhoneNumber,
                    nombre = e.nombre,
                    primerapellido = e.primerapellido,
                    segundopellido = e.segundoapellido,
                    localidad = e.localidad.nombre,
                    codigo_postal = e.localidad.cp,
                    provincia = e.localidad.provincia.nombre,
                    pais = e.localidad.provincia.pais.nombre
                }).ToList();

               
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = usuarios;
                return resp.ObjectoRespuesta();

            }
            catch (Exception ex)
            {
                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
        }
        
    }
}