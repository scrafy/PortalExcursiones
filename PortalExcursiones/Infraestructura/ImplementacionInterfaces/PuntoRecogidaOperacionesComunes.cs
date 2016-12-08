using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaDatos.Entidades;
using CapaDatos.Identity;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using Microsoft.Owin.Security;
using PortalExcursiones.Modelos.ModelosSalida;
using Microsoft.AspNet.Identity;
using PortalExcursiones.Infraestructura.Enumeraciones;
using CapaDatos;
using System.Data.Entity;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class PuntoRecogidaOperacionesComunes : IOperacionesComunes<puntorecogida>
    {
        private Contexto contexto;
        private Respuesta resp;

        public PuntoRecogidaOperacionesComunes(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }


        public HttpResponseMessage Actualizar(puntorecogida Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    var puntorecogida = contexto.puntorecogida.Where(x => x.nombre.ToLower() == Entidad.nombre.ToLower() && x.id != Entidad.id).FirstOrDefault();
                    if (puntorecogida != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        return resp.ObjectoRespuesta();
                    }
                    puntorecogida = contexto.puntorecogida.Find(Entidad.id);
                    if (puntorecogida == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        return resp.ObjectoRespuesta();
                    }
                    contexto.Entry(puntorecogida).State = EntityState.Detached;
                    contexto.Entry(Entidad).State = EntityState.Modified;
                    contexto.SaveChanges();
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
        
        public HttpResponseMessage Crear(puntorecogida Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    var puntorecogida = contexto.puntorecogida.Where(x => x.nombre.ToLower() == Entidad.nombre.ToLower()).FirstOrDefault();
                    if(puntorecogida != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        return resp.ObjectoRespuesta();
                    }
                    contexto.puntorecogida.Add(Entidad);
                    contexto.SaveChanges();
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
                var _id = Int64.Parse(id);
                var puntorecogida = contexto.puntorecogida.Where(x => x.id == _id).Select(x => new
                {
                    id = x.id,
                    nombre = x.nombre,
                    lat = x.lat,
                    lng = x.lng,
                    direccion = x.direccion,
                    localidad = x.localidad.nombre,
                    provincia = x.localidad.provincia.nombre,
                    pais = x.localidad.provincia.pais.nombre,
                    descripcion = x.descripcion
                }).FirstOrDefault();

                if (puntorecogida == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = puntorecogida;
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
                var puntosrecogida = contexto.puntorecogida.Select(x => new
                {
                    id = x.id,
                    nombre = x.nombre,
                    lat = x.lat,
                    lng = x.lng,
                    direccion = x.direccion,
                    localidad = x.localidad.nombre,
                    provincia = x.localidad.provincia.nombre,
                    pais = x.localidad.provincia.pais.nombre,
                    descripcion = x.descripcion
                }).ToList();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = puntosrecogida;
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