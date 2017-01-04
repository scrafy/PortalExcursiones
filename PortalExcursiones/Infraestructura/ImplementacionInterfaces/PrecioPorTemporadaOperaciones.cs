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
using System.Web;
using System.Collections.Generic;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class PrecioPorTemporadaOperaciones : Operaciones,IOperacionesComunes<preciotemporada>
    {

        private Contexto contexto;
        private Respuesta resp;

        public PrecioPorTemporadaOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(preciotemporada Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                    var preciotemporada = contexto.preciotemporada.Where(x => x.excursionactividad.configuracion.proveedor_id == proveedor_id && x.id == Entidad.id).FirstOrDefault();
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
                    var datos = contexto.configuracion.Where(x => x.id == Entidad.exact_id).Select(x => new
                    {
                        porcentaje = x.porcentaje,
                        esporgrupo = x.excursionactividad.precioporgrupo,
                        secontabilizaninfantes = x.excursionactividad.secontabilizaninfantes

                    }).First();
                    if (datos.esporgrupo)
                    {
                        if (Entidad.costegrupo == 0)
                        {
                            resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                            resp.Erroresvalidacion = new string[] { Errores.error31 }.ToList();
                            return resp.ObjectoRespuesta();
                        }
                        Entidad.pvpgrupo = Entidad.costegrupo + (Entidad.costegrupo * (datos.porcentaje / 100));
                        Entidad.netogrupo = Entidad.pvpgrupo - Entidad.costegrupo;
                    }
                    else
                    {
                        if (datos.secontabilizaninfantes)
                        {
                            if (Entidad.costeinfante == 0)
                            {
                                resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                                resp.Erroresvalidacion = new string[] { Errores.error32 }.ToList();
                                return resp.ObjectoRespuesta();
                            }
                        }
                        Entidad.pvpadulto = Entidad.costeadulto + (Entidad.costeadulto * (datos.porcentaje / 100));
                        Entidad.pvpinfante = Entidad.costeinfante + (Entidad.costeinfante * (datos.porcentaje / 100));
                        Entidad.pvpjunior = Entidad.costejunior + (Entidad.costejunior * (datos.porcentaje / 100));
                        Entidad.pvpnino = Entidad.costenino + (Entidad.costenino * (datos.porcentaje / 100));
                        Entidad.pvpsenior = Entidad.costesenior + (Entidad.costesenior * (datos.porcentaje / 100));

                        Entidad.netoadulto = Entidad.pvpadulto - Entidad.costeadulto;
                        Entidad.netoinfante = Entidad.pvpinfante - Entidad.costeinfante;
                        Entidad.netojunior = Entidad.pvpjunior - Entidad.costejunior;
                        Entidad.netonino = Entidad.pvpnino - Entidad.costenino;
                        Entidad.netosenior = Entidad.pvpsenior - Entidad.costesenior;
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
                if (modelo.IsValid)
                {
                    var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                    if (Entidad.desde>=Entidad.hasta)
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
                    var datos = contexto.configuracion.Where(x => x.id == Entidad.exact_id && x.proveedor_id == proveedor_id).Select(x => new
                    {
                        porcentaje = x.porcentaje,
                        esporgrupo = x.excursionactividad.precioporgrupo,
                        secontabilizaninfantes = x.excursionactividad.secontabilizaninfantes

                    }).FirstOrDefault();
                    if(datos == null)
                    {
                        resp.Codigo = (int)Codigos.ERROR_OPERACION_NO_PERMITIDA;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_OPERACION_NO_PERMITIDA);
                        return resp.ObjectoRespuesta();
                    }
                    if(datos.esporgrupo)
                    {
                        if(Entidad.costegrupo == 0)
                        {
                            resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                            resp.Erroresvalidacion = new string[] { Errores.error31 }.ToList();
                            return resp.ObjectoRespuesta();
                        }
                        Entidad.pvpgrupo = Entidad.costegrupo + (Entidad.costegrupo * (datos.porcentaje / 100));
                        Entidad.netogrupo = Entidad.pvpgrupo - Entidad.costegrupo;
                    }
                    else
                    {
                        if(datos.secontabilizaninfantes)
                        {
                            if(Entidad.costeinfante == 0)
                            {
                                resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                                resp.Erroresvalidacion = new string[] { Errores.error32 }.ToList();
                                return resp.ObjectoRespuesta();
                            }
                        }
                        Entidad.pvpadulto = Entidad.costeadulto + (Entidad.costeadulto * (datos.porcentaje / 100));
                        Entidad.pvpinfante = Entidad.costeinfante + (Entidad.costeinfante * (datos.porcentaje / 100));
                        Entidad.pvpjunior = Entidad.costejunior + (Entidad.costejunior * (datos.porcentaje / 100));
                        Entidad.pvpnino = Entidad.costenino + (Entidad.costenino * (datos.porcentaje / 100));
                        Entidad.pvpsenior = Entidad.costesenior + (Entidad.costesenior * (datos.porcentaje / 100));

                        Entidad.netoadulto = Entidad.pvpadulto - Entidad.costeadulto;
                        Entidad.netoinfante = Entidad.pvpinfante - Entidad.costeinfante;
                        Entidad.netojunior = Entidad.pvpjunior - Entidad.costejunior;
                        Entidad.netonino = Entidad.pvpnino - Entidad.costenino;
                        Entidad.netosenior = Entidad.pvpsenior - Entidad.costesenior;
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

        public HttpResponseMessage Todos(int pag_actual, int regxpag)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var _aux = contexto.preciotemporada.Include(e => e.excursionactividad.configuracion).Where(x => x.excursionactividad.configuracion.proveedor_id == proveedor_id).OrderBy(x => x.id).Skip((pag_actual - 1) * regxpag).Take(regxpag).ToList();
                var aux = _aux.GroupBy(x => x.excursionactividad.configuracion.nombre);
                var output = new Dictionary<string, List<preciotemporada>>();
                List<preciotemporada> _precios = null;
                foreach (var exact in aux)
                {
                    _precios = new List<preciotemporada>();
                    foreach (var p in exact)
                    {
                       _precios.Add(p);
                    }
                    output.Add(exact.Key,_precios);
                }
                var paginacion = this.Paginacion(contexto.preciotemporada.Where(x => x.excursionactividad.configuracion.proveedor_id == proveedor_id).Count(), pag_actual, regxpag);
                var result = new
                {
                    precios = output,
                    paginacion = paginacion
                };
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = result;
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
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var _id = Int64.Parse(id);
                var destino = contexto.preciotemporada.Where(x => x.excursionactividad.configuracion.proveedor_id == proveedor_id&& x.id == _id).FirstOrDefault();
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

        public HttpResponseMessage Eliminar(string id)
        {
            throw new NotImplementedException();
        }
    }
}