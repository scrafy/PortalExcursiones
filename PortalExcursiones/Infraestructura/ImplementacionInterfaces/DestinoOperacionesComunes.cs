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

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class DestinoOperacionesComunes : IOperacionesComunes<destino>
    {

        private Contexto contexto;
        private Respuesta resp;

        public DestinoOperacionesComunes(Contexto _contexto,Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }


        public HttpResponseMessage Actualizar(destino Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    var destino = contexto.destino.Where(x => x.nombre.ToLower() == Entidad.nombre.ToLower() && x.id!=Entidad.id).FirstOrDefault();
                    if(destino != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        return resp.ObjectoRespuesta();
                    }
                    destino = contexto.destino.Find(Entidad.id);
                    if(destino == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        return resp.ObjectoRespuesta();
                    }
                    destino.nombre = Entidad.nombre;
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
                var destino = contexto.destino.Where(x=>x.id ==_id).Select(x => new { id = x.id, nombre = x.nombre }).FirstOrDefault();
                if(destino == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = destino;
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

        public HttpResponseMessage Crear(destino Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    if(contexto.destino.Where(x=>x.nombre.ToLower()==Entidad.nombre.ToLower()).FirstOrDefault()!=null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        return resp.ObjectoRespuesta();
                    }
                    contexto.destino.Add(new destino() { nombre = Entidad.nombre });
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

        public HttpResponseMessage Todos()
        {
            try
            {
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = contexto.destino.Select(x=>new{id=x.id,nombre=x.nombre }).ToList();
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