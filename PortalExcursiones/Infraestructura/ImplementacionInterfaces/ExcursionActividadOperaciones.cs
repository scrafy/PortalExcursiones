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
using System.Collections.Generic;
using PortalExcursiones.Modelos.ModelosEntrada;
using Microsoft.AspNet.Identity;
using System.Web;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class ExcursionActividadOperaciones : Operaciones,IOperacionesComunes<excursionactividad>, IOperacionesExcursionActividad
    {

        private Contexto contexto;
        private Respuesta resp;

        public ExcursionActividadOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(excursionactividad Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    var proveedor_id = HttpContext.Current.User.Identity.GetUserId();

                    if ((Entidad.tipoactividad_id == 0 || Entidad.tipoactividad_id == null) && (Entidad.tipoexcursion_id == 0 || Entidad.tipoexcursion_id == null))
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
                    if(Entidad.esexcursion)
                    {
                        Entidad.tipoactividad_id = null;
                    }
                    else
                    {
                        Entidad.tipoexcursion_id = null;
                    }
                    var exact = contexto.excursionactividad.Include("configuracion").Where(x => x.exact_id == Entidad.configuracion.id && x.configuracion.proveedor_id == proveedor_id).FirstOrDefault();
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
                    if(Entidad.configuracion.fotos != null && Entidad.configuracion.fotos.Count > 0)
                    {
                        Entidad.configuracion.fotos = null;
                    }
                    var duraciones = Enum.GetNames(typeof(DuracionExAct));
                    if (duraciones.Where(x => x == Entidad.tipoduracion.ToLower()).FirstOrDefault() == null)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] { Errores.error28 };
                        return resp.ObjectoRespuesta();
                    }
                    Entidad.tipoduracion = Entidad.tipoduracion.ToLower();
                    if(Entidad.tipoduracion.Equals("flexible"))
                    {
                        Entidad.duracion = 0;
                    }
                    else if (Entidad.duracion <= 0)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] { Errores.error29 };
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
                    if(Entidad.esexcursion)
                    {
                        Entidad.tipoactividad_id = null;
                    }
                    else
                    {
                        Entidad.tipoexcursion_id = null;
                    }
                    if (contexto.configuracion.Where(x=>x.nombre.ToLower() == Entidad.configuracion.nombre.ToLower()).FirstOrDefault()!=null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = Errores.error10;
                        return resp.ObjectoRespuesta();
                    }
                    var fotos = Entidad.configuracion.fotos.ToList();
                    Entidad.configuracion.fotos = null;
                    tran = contexto.Database.BeginTransaction();
                    contexto.configuracion.Add(Entidad.configuracion);
                    contexto.SaveChanges();
                    foreach(var foto in fotos)
                    {
                        foto.configuracion_id = Entidad.configuracion.id;
                        contexto.fotoconfiguracion.Add(foto);
                    }
                    var duraciones = Enum.GetNames(typeof(DuracionExAct));
                    if(duraciones.Where(x=>x==Entidad.tipoduracion.ToLower()).FirstOrDefault() == null)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[]{ Errores.error28 };
                        return resp.ObjectoRespuesta();
                    }
                    Entidad.tipoduracion = Entidad.tipoduracion.ToLower();
                    if(Entidad.tipoduracion.Equals("flexible"))
                    {
                        Entidad.duracion = 0;
                    }
                    else if(Entidad.duracion <=0)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] { Errores.error29 };
                        return resp.ObjectoRespuesta();
                    }
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

        public HttpResponseMessage Todos(int pag_actual,int regxpag)
        {
            try
            {
               var proveedorid = HttpContext.Current.User.Identity.GetUserId<string>();
               var excursiones =
               (
                 from x in contexto.excursionactividad
                 where x.configuracion.proveedor_id == proveedorid
                 select new
                 {
                     id = x.configuracion.id,
                     nombre = x.configuracion.nombre,
                     ocultarweb = x.configuracion.ocultarweb,
                     video = x.configuracion.video,
                     tripadvisor = x.configuracion.tadvisor,
                     latitud = x.configuracion.lat,
                     longitud = x.configuracion.lng,
                     logo = x.configuracion.logo,
                     duracion = x.duracion,
                     tipoduracion = x.tipoduracion,
                     min_personas = x.minpersonas,
                     max_personas = x.maxpersonas,
                     precioporgrupo = x.precioporgrupo,
                     descuento = x.descuento,
                     queharas = x.queharas,
                     queesperar = x.queesperar,
                     noincluye = x.noincluye,
                     antesdeir = x.antesdeir,
                     esexcursion = x.esexcursion,
                     secontabilizaninfantes = x.secontabilizaninfantes,
                     pickupservice = x.pickupservice,
                     fotos = 
                     (
                        from foto in x.configuracion.fotos select new
                        {
                            id = foto.id,
                            nombre = foto.nombre,
                            url = foto.url
                        } 
                     ),
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
                     fechas = 
                     (
                        from fecha in x.fechas orderby fecha.fecha ascending select new
                        {
                            fecha = fecha.fecha,
                            estado_excursion = fecha.estadoexcursion.nombre                           
                        }
                     ),
                     precios = 
                     (
                        from precio in x.precios select new
                        {
                            desde = precio.desde,
                            hasta = precio.hasta,
                            precio_adulto = precio.pvpadulto,
                            precio_nino = precio.pvpnino,
                            precio_infante = precio.pvpinfante
                        }
                     ),
                     items =
                     (
                        from item in x.items
                        select new
                        {
                            nombre = item.item.nombre,
                            url = item.item.url
                        }
                     ),
                     facturaitems =
                     (
                        from item in x.factura_items
                        select new
                        {
                            id = item.item.id,
                            nombre = item.item.nombre,
                            descripcion = item.item.descripcion
                        }
                     ),
                     idiomas = from idioma in x.idiomas select new
                     {
                        id = idioma.idioma_id,
                        lenguage = idioma.idioma.lenguage,
                        guia = idioma.guia ? 1 : 0,
                        guia_escrita = idioma.guia_escrita ? 1 : 0,
                        audio_auricular = idioma.audio_auricular ? 1 : 0
                     },
                     edades = from edad in x.grupoedades
                    select new
                    {
                        id = edad.id,
                        genero = edad.genero,
                        edaddesde = edad.edaddesde,
                        edadhasta = edad.edadhasta,
                    }
                 }
                     
                ).OrderBy(x => x.nombre).Skip((pag_actual - 1) * regxpag).Take(regxpag).ToList();
                var paginacion = this.Paginacion(contexto.excursionactividad.Where(x => x.configuracion.proveedor_id == proveedorid).Count(), pag_actual, regxpag);
                var result = new
                {
                    excursiones = excursiones,
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
                Int64 _id = Int64.Parse(id);
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                if (contexto.excursionactividad.Where(x=>x.exact_id == _id).FirstOrDefault() == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    resp.Mensaje_error = Errores.error6;
                    return resp.ObjectoRespuesta();
                }

                var excursion =
                (
                  from x in contexto.excursionactividad.Where(c=>c.exact_id==_id && c.configuracion.proveedor_id == proveedor_id)
                  select new
                  {
                      id = x.configuracion.id,
                      nombre = x.configuracion.nombre,
                      ocultarweb = x.configuracion.ocultarweb,
                      video = x.configuracion.video,
                      tripadvisor = x.configuracion.tadvisor,
                      latitud = x.configuracion.lat,
                      longitud = x.configuracion.lng,
                      logo = x.configuracion.logo,
                      duracion = x.duracion,
                      tipoduracion = x.tipoduracion,
                      min_personas = x.minpersonas,
                      max_personas = x.maxpersonas,
                      precioporgrupo = x.precioporgrupo,
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
                      fechas =
                      (
                        from fecha in x.fechas  orderby fecha.fecha ascending select new
                        {
                            fecha = fecha.fecha,
                            estado_excursion = fecha.estadoexcursion.nombre
                        }
                     ),
                     precios =
                     (
                         from precio in x.precios select new
                         {
                            desde = precio.desde,
                            hasta = precio.hasta,
                            precio_adulto = precio.pvpadulto,
                            precio_nino = precio.pvpnino,
                            precio_infante = precio.pvpinfante
                        }
                     ),
                     items =
                     (
                        from item in x.items select new
                        {
                            nombre = item.item.nombre,
                            url = item.item.url
                        }
                     ),
                     facturaitems =
                     (
                        from item in x.factura_items
                        select new
                        {
                            id = item.item.id,
                            nombre = item.item.nombre,
                            descripcion = item.item.descripcion
                        }
                     ),
                      idiomas = from idioma in x.idiomas select new
                     {
                         id = idioma.idioma_id,
                         lenguage = idioma.idioma.lenguage,
                         guia = idioma.guia ? 1 : 0,
                         guia_escrita = idioma.guia_escrita ? 1 : 0,
                         audio_auricular = idioma.audio_auricular ? 1 : 0
                     },
                    edades = from edad in x.grupoedades
                    select new
                    {
                        id = edad.id,
                        genero = edad.genero,
                        edaddesde = edad.edaddesde,
                        edadhasta = edad.edadhasta,
                    }


                  }  
                 
                ).ToList();
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

        public HttpResponseMessage AnadirItem(long item_id, long exact_id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();

                if (contexto.excursion_contiene_item.Where(x=>x.exact_id == exact_id && x.item_id == item_id).FirstOrDefault() != null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                    return resp.ObjectoRespuesta();
                }
                if(contexto.configuracion.Where(x => x.id == exact_id && x.proveedor_id == proveedor_id).FirstOrDefault() == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.excursion_contiene_item.Add(new excursion_contiene_item(){item_id = item_id,exact_id = exact_id });
                contexto.SaveChanges();
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

        public HttpResponseMessage EliminarItem(long item_id, long exact_id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var item = contexto.excursion_contiene_item.Where(x => x.exact_id == exact_id && x.item_id == item_id && x.excursionactividad.configuracion.proveedor_id == proveedor_id).FirstOrDefault();
                if(item == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.excursion_contiene_item.Remove(item);
                contexto.SaveChanges();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
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

        public HttpResponseMessage AnadirIdioma(List<IdiomaExActModel> idiomas)
        {
           try
           {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                if (contexto.configuracion.Where(x => x.id == idiomas[0].Exact_id && x.proveedor_id == proveedor_id).FirstOrDefault() == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                idiomas.ForEach(x => contexto.idioma_exact.Add(new idioma_exact()
                {
                    exact_id = x.Exact_id,
                    idioma_id = x.Idioma_id,
                    guia = x.Guia,
                    guia_escrita = x.Guia_escrita,
                    audio_auricular = x.Audio_auricular

                }));
                contexto.SaveChanges();
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

        public HttpResponseMessage EliminarIdioma(int idioma_id, long exact_id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var idioma = contexto.idioma_exact.Where(x => x.exact_id == exact_id && x.idioma_id == idioma_id && x.excursion_actividad.configuracion.proveedor_id == proveedor_id).FirstOrDefault();
                if (idioma == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.idioma_exact.Remove(idioma);
                contexto.SaveChanges();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
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

        public HttpResponseMessage AnadirItemFactura(List<FacturaItemModel> items)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                if (contexto.configuracion.Where(x => x.id == items[0].Exact_id && x.proveedor_id == proveedor_id).FirstOrDefault() == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                items.ForEach(x=>
                contexto.facturaitem_exact.Add(new facturaitem_exact()
                {
                    item_id = x.Item_id,
                    exact_id = x.Exact_id
                }));
                contexto.SaveChanges();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
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

        public HttpResponseMessage EliminarItemFactura(long item_id, long exact_id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var item = contexto.facturaitem_exact.Where(x => x.exact_id == exact_id && x.item_id == item_id && x.exact.configuracion.proveedor_id == proveedor_id).FirstOrDefault();
                if (item == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.facturaitem_exact.Remove(item);
                contexto.SaveChanges();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
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

        public HttpResponseMessage AnadirPunto(List<PuntoModel> puntos)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                if (contexto.configuracion.Where(x => x.id == puntos[0].Exact_id && x.proveedor_id == proveedor_id).FirstOrDefault() == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                puntos.ForEach(x =>
                contexto.punto_exact.Add(new puntorecogida_exact()
                {
                    punto_id = x.Punto_id,
                    exact_id = x.Exact_id
                }));
                contexto.SaveChanges();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
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

        public HttpResponseMessage EliminarPunto(PuntoModel punto)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var _punto = contexto.punto_exact.Where(x => x.exact_id == punto.Exact_id && x.punto_id == punto.Punto_id && x.punto.proveedor_id == proveedor_id).FirstOrDefault();
                if (_punto == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.punto_exact.Remove(_punto);
                contexto.SaveChanges();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
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

        public HttpResponseMessage GrupoEdad(long exact_id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var grupoedad = contexto.grupoedad.Where(x => x.exact_id == exact_id && x.exact.configuracion.proveedor_id == proveedor_id).Select(x=>new
                {
                    id = x.id,
                    edaddesde = x.edaddesde,
                    edadhasta = x.edadhasta,
                    genero = x.genero,
                    nombre_configuracion = x.exact.configuracion.nombre

                }).OrderBy(x=>x.edaddesde).ToList();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = grupoedad;
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