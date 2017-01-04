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
using PortalExcursiones.Modelos.ModelosEntrada;
using PortalExcursiones.Properties;
using System.Threading.Tasks;
using System.Threading;
using PortalExcursiones.Infraestructura.LogicaComun;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class PuntoRecogidaOperaciones : Operaciones,IOperacionesPuntoRecogida
    {
        private Contexto contexto;
        private Respuesta resp;

        public PuntoRecogidaOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }


        public HttpResponseMessage Actualizar(PuntoRecogidaModel punto, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    if(punto.Id == 0)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] {ErroresValidacion.error17 };
                        return resp.ObjectoRespuesta();
                    }
                    var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                    var puntorecogida = contexto.puntorecogida.Where(x => x.nombre.ToLower() == punto.Nombre.ToLower() && x.id != punto.Id && x.proveedor_id == proveedor_id).FirstOrDefault();
                    if (puntorecogida != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = Errores.error20;
                        return resp.ObjectoRespuesta();
                    }
                    puntorecogida = contexto.puntorecogida.Where(x => x.id == punto.Id && x.proveedor_id == proveedor_id).FirstOrDefault();
                    if (puntorecogida == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        return resp.ObjectoRespuesta();
                    }
                    puntorecogida.nombre = punto.Nombre;
                    puntorecogida.lat = punto.Lat;
                    puntorecogida.lng = punto.Lng;
                    puntorecogida.localidad_id = punto.Localidad_id;
                    puntorecogida.descripcion = punto.Descripcion;
                    puntorecogida.direccion = punto.Direccion;
                    contexto.SaveChanges();
                    Task.Run(() => GestionAvisosEmail.PuntoRecogidaModificado(punto.Id, contexto));
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

        public HttpResponseMessage BusquedaPorId(long id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var puntorecogida = contexto.puntorecogida.Where(x => x.id == id && x.proveedor_id == proveedor_id).Select(x => new
                {
                    id = x.id,
                    nombre = x.nombre,
                    lat = x.lat,
                    lng = x.lng,
                    direccion = x.direccion,
                    localidad_id = x.localidad_id,
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

        public HttpResponseMessage BusquedaPorExAct(long id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var puntorecogida = contexto.punto_exact.Where(x => x.exact_id == id && x.excursion_actividad.configuracion.proveedor_id == proveedor_id).Select(x => new
                {
                    id = x.punto.id,
                    nombre = x.punto.nombre,
                    lat = x.punto.lat,
                    lng = x.punto.lng,
                    direccion = x.punto.direccion,
                    localidad_id = x.punto.localidad_id,
                    localidad = x.punto.localidad.nombre,
                    provincia = x.punto.localidad.provincia.nombre,
                    pais = x.punto.localidad.provincia.pais.nombre,
                    descripcion = x.punto.descripcion

                }).ToList();
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


        public HttpResponseMessage Todos(int pag_actual,int regxpag)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var puntosrecogida = contexto.puntorecogida.Where(x => x.proveedor_id == proveedor_id).Select(x => new
                {
                    id = x.id,
                    nombre = x.nombre,
                    lat = x.lat,
                    lng = x.lng,
                    direccion = x.direccion,
                    localidad_id = x.localidad_id,
                    localidad = x.localidad.nombre,
                    provincia = x.localidad.provincia.nombre,
                    pais = x.localidad.provincia.pais.nombre,
                    descripcion = x.descripcion
                }).OrderBy(x => x.nombre).Skip((pag_actual - 1) * regxpag).Take(regxpag).ToList();
                var paginacion = this.Paginacion(contexto.puntorecogida.Where(x => x.proveedor_id == proveedor_id).Count(), pag_actual, regxpag);
                var result = new
                {
                    puntosrecogida = puntosrecogida,
                    paginacion = paginacion
                };
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = result;
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

        public HttpResponseMessage Crear(PuntoRecogidaModel punto, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                    var puntorecogida = contexto.puntorecogida.Where(x => x.nombre.ToLower() == punto.Nombre.ToLower() && x.proveedor_id == proveedor_id).FirstOrDefault();
                    if (puntorecogida != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = Errores.error20;
                        return resp.ObjectoRespuesta();
                    }
                    var _punto = contexto.puntorecogida.Add(new puntorecogida()
                    {
                        lat = punto.Lat,
                        lng = punto.Lng,
                        nombre = punto.Nombre,
                        descripcion = punto.Descripcion,
                        direccion = punto.Direccion,
                        localidad_id = punto.Localidad_id,
                        proveedor_id = proveedor_id
                    });
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

        public HttpResponseMessage Eliminar(long id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var puntos = contexto.punto_exact.Where(x => x.punto_id == id && x.punto.proveedor_id == proveedor_id).ToList();
                if(puntos.Count > 0)
                {
                    puntos.ForEach(x => contexto.punto_exact.Remove(x));
                }
                var punto = contexto.puntorecogida.Where(x => x.id == id && x.proveedor_id == proveedor_id).FirstOrDefault();
                if(punto == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                var reservas = contexto.reservaexcursionactividad.Where(x => x.punto_id == id).ToList();
                reservas.ForEach(x => x.punto_id = null);
                contexto.puntorecogida.Remove(punto);
                contexto.SaveChanges();
                Task.Run(() => GestionAvisosEmail.PuntoRecogidaEliminado(id, contexto));
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
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
        
    }
}