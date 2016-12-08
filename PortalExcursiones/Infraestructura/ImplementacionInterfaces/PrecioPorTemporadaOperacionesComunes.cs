using System;
using System.Linq;
using System.Net.Http;
using CapaDatos.Identity;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using CapaDatos;
using CapaDatos.Entidades;
using PortalExcursiones.Properties;
using System.Data.Entity;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Infraestructura.Enumeraciones;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class PrecioPorTemporadaOperacionesComunes : IOperacionesComunes<preciotemporada>
    {

        private Contexto contexto;
        private Respuesta resp;

        public PrecioPorTemporadaOperacionesComunes(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(preciotemporada Entidad, ModelStateDictionary modelo)
        {
            try
            {
                Entidad.desde = new DateTime(Entidad.desde.Year, Entidad.desde.Day, Entidad.desde.Month, Entidad.desde.Hour, Entidad.desde.Minute, Entidad.desde.Second);
                Entidad.hasta = new DateTime(Entidad.hasta.Year, Entidad.hasta.Day, Entidad.hasta.Month, Entidad.hasta.Hour, Entidad.hasta.Minute, Entidad.hasta.Second);
                if (modelo.IsValid)
                {
                    var preciotemporada = contexto.preciotemporada.Find(Entidad.id);
                    if (preciotemporada == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = Errores.error6;
                        return resp.ObjectoRespuesta();
                    }
                    if (Entidad.desde >= Entidad.hasta)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { Errores.error13 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    var maxima = contexto.preciotemporada.Where
                    (
                        x => x.exact_id == Entidad.exact_id && x.id != Entidad.id
                        &&
                        (
                            (Entidad.hasta >= x.desde && Entidad.desde < x.desde)  ||  
                            (Entidad.desde >= x.desde && Entidad.hasta <= x.hasta) ||
                            (Entidad.desde <= x.hasta && Entidad.hasta > x.hasta)
                        )
                    ).FirstOrDefault();
                    if(maxima != null)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { Errores.error12 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    contexto.Entry(preciotemporada).State = EntityState.Detached;
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

        public HttpResponseMessage Crear(preciotemporada Entidad, ModelStateDictionary modelo)
        {
            try
            {
                Entidad.desde = new DateTime(Entidad.desde.Year, Entidad.desde.Day, Entidad.desde.Month, Entidad.desde.Hour, Entidad.desde.Minute, Entidad.desde.Second);
                Entidad.hasta = new DateTime(Entidad.hasta.Year, Entidad.hasta.Day, Entidad.hasta.Month, Entidad.hasta.Hour, Entidad.hasta.Minute, Entidad.hasta.Second);
                if (modelo.IsValid)
                {
                    if(Entidad.desde>=Entidad.hasta)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[]{Errores.error13}.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    var maxima = contexto.preciotemporada.Where
                    (
                        x => x.exact_id == Entidad.exact_id
                        &&
                        (
                            (Entidad.hasta >= x.desde && Entidad.desde < x.desde) ||
                            (Entidad.desde >= x.desde && Entidad.hasta <= x.hasta) ||
                            (Entidad.desde <= x.hasta && Entidad.hasta > x.hasta)
                        )
                    ).FirstOrDefault();
                    if(maxima != null)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[]{Errores.error12}.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    contexto.preciotemporada.Add(Entidad);
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
                resp.Contenido = contexto.preciotemporada.ToList();
                return resp.ObjectoRespuesta();
            }
            catch(Exception ex)
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
                var destino = contexto.preciotemporada.Find(_id);
                if (destino == null)
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

    }
}