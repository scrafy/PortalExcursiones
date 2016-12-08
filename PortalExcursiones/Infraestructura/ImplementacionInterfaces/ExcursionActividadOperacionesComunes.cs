using PortalExcursiones.Infraestructura.Interfaces;
using System;
using CapaDatos.Entidades;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using CapaDatos;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Linq;
using PortalExcursiones.Infraestructura.Enumeraciones;
using PortalExcursiones.Properties;
using System.Data.Entity;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class ExcursionActividadOperacionesComunes : IOperacionesComunes<excursionactividad>
    {

        private Contexto contexto;
        private Respuesta resp;

        public ExcursionActividadOperacionesComunes(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(excursionactividad Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    if((Entidad.tipoactividad_id == 0 || Entidad.tipoactividad_id == null) && (Entidad.tipoexcursion_id == 0 || Entidad.tipoexcursion_id == null))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { ErroresValidacion.error18 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if ((Entidad.tipoactividad_id != 0 && Entidad.tipoactividad_id != null && Entidad.tipoexcursion_id != 0 && Entidad.tipoexcursion_id != null))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { ErroresValidacion.error19 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if ((Entidad.esexcursion) && (Entidad.tipoexcursion_id == 0 || Entidad.tipoexcursion_id == null))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { ErroresValidacion.error20 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if ((!Entidad.esexcursion) && (Entidad.tipoactividad_id == 0 || Entidad.tipoactividad_id == null))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { ErroresValidacion.error21 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    var exact = contexto.excursionactividad.Include("configuracion").Where(x => x.exact_id == Entidad.configuracion.id).FirstOrDefault();
                    if(exact == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        return resp.ObjectoRespuesta();
                    }
                    if(contexto.configuracion.Where(x=>x.nombre.ToLower() == Entidad.configuracion.nombre.ToLower() && x.id!=Entidad.configuracion.id).FirstOrDefault() != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = Errores.error10;
                        return resp.ObjectoRespuesta();
                    }
                    Entidad.exact_id = Entidad.configuracion.id;
                    Entidad.configuracion.proveedor_id = exact.configuracion.proveedor_id;
                    Entidad.tipoactividad_id = Entidad.tipoactividad_id == null || Entidad.tipoactividad_id == 0 ? exact.tipoactividad_id : Entidad.tipoactividad_id;
                    Entidad.tipoexcursion_id = Entidad.tipoexcursion_id == null || Entidad.tipoexcursion_id == 0 ? Entidad.tipoexcursion_id : Entidad.tipoexcursion_id;
                    contexto.Entry(exact.configuracion).State = EntityState.Detached;
                    contexto.Entry(exact).State = EntityState.Detached;
                    contexto.Entry(Entidad).State = EntityState.Modified;
                    contexto.Entry(Entidad.configuracion).State = EntityState.Modified;
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

        public HttpResponseMessage Crear(excursionactividad Entidad, ModelStateDictionary modelo)
        {
           DbContextTransaction tran = null;
           try
           {
                if(modelo.IsValid)
                {
                    if((Entidad.tipoactividad_id==0 || Entidad.tipoactividad_id == null) && (Entidad.tipoexcursion_id == 0 || Entidad.tipoexcursion_id == null))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[]{ErroresValidacion.error18}.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if((Entidad.tipoactividad_id != 0 && Entidad.tipoactividad_id != null && Entidad.tipoexcursion_id != 0 && Entidad.tipoexcursion_id != null)) 
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] {ErroresValidacion.error19 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if ((Entidad.esexcursion) && (Entidad.tipoexcursion_id == 0 || Entidad.tipoexcursion_id == null))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { ErroresValidacion.error20 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if((!Entidad.esexcursion) && (Entidad.tipoactividad_id == 0 || Entidad.tipoactividad_id == null))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { ErroresValidacion.error21 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if (contexto.configuracion.Where(x=>x.nombre.ToLower() == Entidad.configuracion.nombre.ToLower()).FirstOrDefault()!=null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = Errores.error10;
                        return resp.ObjectoRespuesta();
                    }

                    tran = contexto.Database.BeginTransaction();
                    contexto.configuracion.Add(Entidad.configuracion);
                    contexto.SaveChanges();
                    contexto.excursionactividad.Add(Entidad);
                    contexto.SaveChanges();
                    tran.Commit();
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
           catch(Exception ex)
           {
                if (contexto.Database.CurrentTransaction != null)
                    tran.Rollback();

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
                var excursiones = contexto.excursionactividad.Select(x => new
                {
                    id = x.configuracion.id,
                    nombre = x.configuracion.nombre,
                    ocultarweb = x.configuracion.ocultarweb,
                    video = x.configuracion.video,
                    tripadvisor = x.configuracion.tadvisor,
                    latitud = x.configuracion.lat,
                    longitud = x.configuracion.lng,
                    logo = x.configuracion.logo,
                    horas_duracion = x.duracion,
                    min_personas = x.minpersonas,
                    max_personas = x.maxpersonas,
                    descuento = x.descuento,
                    queharas = x.queharas,
                    queesperar = x.queesperar,
                    noincluye = x.noincluye,
                    antesdeir = x.antesdeir,
                    esexcursion = x.esexcursion,
                    secontabilizaninfantes = x.secontabilizaninfantes,
                    pickupservice = x.pickupservice,
                    destino = new
                    {
                        id = x.destino.id,
                        nombre = x.destino.nombre
                    },
                    tipoexcursion = new
                    {
                        id = x.categoriaexcursion.id,
                        nombre = x.categoriaexcursion.nombre
                    },
                    tipoactividad = new
                    {
                        id = x.categoriactividad.id,
                        nombre = x.categoriactividad.nombre
                    },
                    fechas = x.fechas.Select(p => new
                    {
                        fecha = p.fecha,
                        estado_excursion = p.estadoexcursion.nombre,
                        puntos_recogida = p.puntosrecogida.Select(t => new
                        {
                            nombre = t.puntorecogida.nombre,
                            latitud = t.puntorecogida.lat,
                            longitud = t.puntorecogida.lng,
                            direccion = t.puntorecogida.direccion,
                            pais = t.puntorecogida.localidad.provincia.pais.nombre,
                            provincia = t.puntorecogida.localidad.provincia.nombre,
                            localidad = t.puntorecogida.localidad.nombre,
                            guias = t.calendarioexcursion.guias.Select(r =>new
                            {
                                nombre = r.guia.usuario.nombre,
                                primerapellido = r.guia.usuario.primerapellido,
                                segundoapellido = r.guia.usuario.segundoapellido,
                                email = r.guia.usuario.Email,
                                pais = r.guia.usuario.localidad.provincia.pais.nombre,
                                provincia = r.guia.usuario.localidad.provincia.nombre,
                                localidad = r.guia.usuario.localidad.nombre,
                                idiomas = r.guia.idiomas.Select(v => new
                                {
                                    nombre = v.idioma.nombre
                                }),

                            })
                        }),
                       
                     }),
                     precios = x.precios.OrderBy(f => f.desde).Select(c => new
                    {
                        desde = c.desde,
                        hasta = c.hasta,
                        precio_adulto = c.pvpadulto,
                        precio_nino = c.pvpnino,
                        precio_infante = c.pvpinfante
                    }),
                    items = x.items.Select(c => new
                    {
                        nombre = c.item.nombre,
                        url = c.item.url
                    })

                }).ToList();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = excursiones;
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
                Int64 _id = Int64.Parse(id);
                if(contexto.excursionactividad.Where(x=>x.exact_id == _id).FirstOrDefault() == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    resp.Mensaje_error = Errores.error6;
                    return resp.ObjectoRespuesta();
                }
                var excursion = contexto.excursionactividad.Where(x=>x.exact_id ==_id).Select(x => new
                {
                    id = x.configuracion.id,
                    nombre = x.configuracion.nombre,
                    ocultarweb = x.configuracion.ocultarweb,
                    video = x.configuracion.video,
                    tripadvisor = x.configuracion.tadvisor,
                    latitud = x.configuracion.lat,
                    longitud = x.configuracion.lng,
                    logo = x.configuracion.logo,
                    horas_duracion = x.duracion,
                    min_personas = x.minpersonas,
                    max_personas = x.maxpersonas,
                    descuento = x.descuento,
                    queharas = x.queharas,
                    queesperar = x.queesperar,
                    noincluye = x.noincluye,
                    antesdeir = x.antesdeir,
                    esexcursion = x.esexcursion,
                    secontabilizaninfantes = x.secontabilizaninfantes,
                    pickupservice = x.pickupservice,
                    destino = new
                    {
                        id = x.destino.id,
                        nombre = x.destino.nombre
                    },
                    tipoexcursion = new
                    {
                        id = x.categoriaexcursion.id,
                        nombre = x.categoriaexcursion.nombre
                    },
                    tipoactividad = new
                    {
                        id = x.categoriactividad.id,
                        nombre = x.categoriactividad.nombre
                    },
                    fechas = x.fechas.Select(p => new
                    {
                        fecha = p.fecha,
                        estado_excursion = p.estadoexcursion.nombre,
                        puntos_recogida = p.puntosrecogida.Select(t => new
                        {
                            nombre = t.puntorecogida.nombre,
                            latitud = t.puntorecogida.lat,
                            longitud = t.puntorecogida.lng,
                            direccion = t.puntorecogida.direccion,
                            pais = t.puntorecogida.localidad.provincia.pais.nombre,
                            provincia = t.puntorecogida.localidad.provincia.nombre,
                            localidad = t.puntorecogida.localidad.nombre,
                            guias = t.calendarioexcursion.guias.Select(r => new
                            {
                                nombre = r.guia.usuario.nombre,
                                primerapellido = r.guia.usuario.primerapellido,
                                segundoapellido = r.guia.usuario.segundoapellido,
                                email = r.guia.usuario.Email,
                                pais = r.guia.usuario.localidad.provincia.pais.nombre,
                                provincia = r.guia.usuario.localidad.provincia.nombre,
                                localidad = r.guia.usuario.localidad.nombre,
                                idiomas = r.guia.idiomas.Select(v => new
                                {
                                    nombre = v.idioma.nombre
                                }),

                            })
                        }),

                    }),
                    precios = x.precios.OrderBy(f => f.desde).Select(c => new
                    {
                        desde = c.desde,
                        hasta = c.hasta,
                        precio_adulto = c.pvpadulto,
                        precio_nino = c.pvpnino,
                        precio_infante = c.pvpinfante
                    }),
                    items = x.items.Select(c => new
                    {
                        nombre = c.item.nombre,
                        url = c.item.url
                    })

                }).ToList();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = excursion;
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