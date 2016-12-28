using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using PortalExcursiones.Modelos.ModelosEntrada;
using PortalExcursiones.Modelos.ModelosSalida;
using CapaDatos.Identity;
using CapaDatos;
using PortalExcursiones.Infraestructura.Enumeraciones;
using System.Globalization;
using System.Threading;
using PortalExcursiones.Properties;
using System.Data.Entity;
using System.Threading.Tasks;
using PortalExcursiones.Infraestructura.LogicaComun;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
   
    public class CalendarioExcursionOperaciones : IOperacionesCalendarioExcursionActividad
    {
        private Contexto contexto = null;
        private Respuesta resp = null;

        public CalendarioExcursionOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Crear(CalendarioExcursionModel datos, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                   
                    if (contexto.excursionactividad.FirstOrDefault(p => p.exact_id == datos.Exact_id)==null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = Errores.error6;
                        return resp.ObjectoRespuesta();
                    }
                    if(datos.Hasta <= datos.Desde)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new List<string>();
                        resp.Erroresvalidacion.Add(Errores.error7);
                        return resp.ObjectoRespuesta();
                    }
                    if(datos.Desde <= DateTime.UtcNow )
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new List<string>();
                        resp.Erroresvalidacion.Add(Errores.error22);
                        return resp.ObjectoRespuesta();
                    }
                    List<calendarioexcursion> inputs = new List<calendarioexcursion>();
                    DateTime aux;
                    List<calendarioexcursion> registradas = contexto.calendarioexcursion.Where(p => p.exact_id == datos.Exact_id && p.fecha >= datos.Desde).ToList<calendarioexcursion>();
                    while(datos.Desde <= datos.Hasta)
                    {
                        aux = datos.Desde;
                        foreach(string hora in datos.Horarios)
                        {
                            aux = aux.AddTicks(TimeSpan.Parse(hora).Ticks);
                            if(datos.Dias.Where(p => p == Enum.GetName(typeof(DiasSemana), (int)aux.DayOfWeek)).FirstOrDefault()!=null)
                            {
                                inputs.Add(new calendarioexcursion() { exact_id = datos.Exact_id, estadoexcursion_id = 1, fecha = aux });
                            }
                            aux = aux.AddTicks(-TimeSpan.Parse(hora).Ticks);
                        }
                        datos.Desde = datos.Desde.AddDays(1);
                    }
                    var query = (from item1 in inputs join item2 in registradas on item1.fecha equals item2.fecha into g from o in g where o.exact_id == datos.Exact_id select new {fecha = o.fecha.ToString("dd/MM/yyyy HH:mm:ss")}).ToList();
                    if (query.Count() == 0)
                    {
                        inputs.ForEach(p => contexto.calendarioexcursion.Add(p));
                        contexto.SaveChanges();
                        resp.Codigo = (int)Codigos.OK;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                        return resp.ObjectoRespuesta();
                    }
                    List<string> salida = new List<string>(query.Count());
                    query.ForEach(p => salida.Add(p.fecha));
                    resp.Codigo = (int)Codigos.ERROR_EXISTEN_FECHAS_REPETIDAS;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_EXISTEN_FECHAS_REPETIDAS);
                    resp.Contenido = salida;
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
                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
        }

        public HttpResponseMessage Eliminar(CalendarioExcursionActualizarEliminarModel datos, ModelStateDictionary modelo)
        {
            try
            {
                if(datos.Fecha <= DateTime.UtcNow)
                {
                    resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                    resp.Erroresvalidacion = new string[] { Errores.error23 }.ToList();
                    return resp.ObjectoRespuesta();
                }
                var calendario = contexto.calendarioexcursion.Where(p => p.exact_id == datos.Exact_id && p.fecha.CompareTo(datos.Fecha) == 0 && p.estadoexcursion_id == (int)EstadoExcursion.activa).FirstOrDefault();
                if(calendario == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                calendario.estadoexcursion_id = (int)EstadoExcursion.anulada;
                contexto.SaveChanges();
                Task.Run(() => GestionAvisosEmail.ExActAnulada(calendario.id, datos.Fecha, contexto));
                //habría que realizar las transferencias para devolver el dinero a los clientes que tenian hecha una reserva para dicha excursion
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


        public HttpResponseMessage Actualizar(CalendarioExcursionActualizarEliminarModel datos, ModelStateDictionary modelo)
        {
            DbContextTransaction tran = null;
            try
            {
                if(modelo.IsValid)
                {
                    if (datos.Fecha <= DateTime.UtcNow)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { Errores.error23 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    if (datos.Fechanueva <= DateTime.UtcNow)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new string[] { Errores.error11 }.ToList();
                        return resp.ObjectoRespuesta();
                    }
                    var calendario = contexto.calendarioexcursion.Where(p => p.exact_id == datos.Exact_id && p.fecha.CompareTo(datos.Fecha) == 0 && p.estadoexcursion_id == (int)EstadoExcursion.activa).FirstOrDefault();
                    if (calendario == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        return resp.ObjectoRespuesta();
                    }
                    if (contexto.calendarioexcursion.Where(p => p.exact_id == datos.Exact_id && p.fecha.CompareTo(datos.Fechanueva) == 0).FirstOrDefault() != null)
                    {
                        resp.Codigo = (int)Codigos.ERROR_EXISTEN_FECHAS_REPETIDAS;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_EXISTEN_FECHAS_REPETIDAS);
                        resp.Mensaje_error = Errores.error9;
                        return resp.ObjectoRespuesta();
                    }
                    tran = contexto.Database.BeginTransaction();
                    calendario.fecha = datos.Fechanueva;
                    contexto.SaveChanges();
                    tran.Commit();
                    Task.Run(() => GestionAvisosEmail.FechaCalendarioModificada(calendario.id,datos.Fechanueva,contexto));
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
                if (contexto.Database.CurrentTransaction != null)
                    tran.Rollback();

                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }

        }

      
    }
}