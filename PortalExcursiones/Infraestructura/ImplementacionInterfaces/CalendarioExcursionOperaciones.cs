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
                    datos.Desde = new DateTime(datos.Desde.Year, datos.Desde.Day, datos.Desde.Month, datos.Desde.Hour, datos.Desde.Minute, datos.Desde.Second);
                    datos.Hasta = new DateTime(datos.Hasta.Year, datos.Hasta.Day, datos.Hasta.Month, datos.Hasta.Hour, datos.Hasta.Minute, datos.Hasta.Second);
                    if (contexto.excursionactividad.FirstOrDefault(p => p.exact_id == datos.Exact_id)==null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = Errores.error6;
                        return resp.ObjectoRespuesta();
                    }
                    if(datos.Hasta < datos.Desde)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Erroresvalidacion = new List<string>();
                        resp.Erroresvalidacion.Add(Errores.error7);
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

        public HttpResponseMessage Eliminar(DateTime fecha, long exact_id)
        {
            try
            {
                DateTime dt = new DateTime(fecha.Year, fecha.Day, fecha.Month, fecha.Hour, fecha.Minute, fecha.Second);
                var calendario = contexto.calendarioexcursion.Where(p => p.exact_id == exact_id && p.fecha.CompareTo(dt) == 0 && p.estadoexcursion_id == (int)EstadoExcursion.activa).FirstOrDefault();
                if(calendario == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                if(calendario.reservas.Count > 0)
                {
                    calendario.estadoexcursion_id = (int)EstadoExcursion.anulada;
                    contexto.SaveChanges();
                    //habría que realizar las transferencias para devolver el dinero a los clientes que tenian hecha una reserva para dicha excursion
                    //avisar a guias,clientes y proveedores de que la excursion/actividad se ha cancelado vía email
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    return resp.ObjectoRespuesta();
                }
                calendario.guias.ToList().ForEach(x => contexto.calendarioexcursion_guia.Remove(x));
                calendario.puntosrecogida.ToList().ForEach(x => contexto.calendarioexcursion_puntorecogida.Remove(x));
                contexto.calendarioexcursion.Remove(calendario);
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


        public HttpResponseMessage Actualizar(DateTime _fecha, DateTime _fechanueva,long exact_id)
        {
            DbContextTransaction tran = null;
            try
            {
                DateTime fecha = new DateTime(_fecha.Year, _fecha.Day, _fecha.Month, _fecha.Hour, _fecha.Minute, _fecha.Second);
                DateTime fechanueva = new DateTime(_fechanueva.Year, _fechanueva.Day, _fechanueva.Month, _fechanueva.Hour, _fechanueva.Minute, _fechanueva.Second);
                if(fechanueva <= DateTime.Now)
                {
                    resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                    resp.Erroresvalidacion = new string[]{Errores.error11}.ToList();
                    return resp.ObjectoRespuesta();
                }
                var calendario = contexto.calendarioexcursion.Where(p => p.exact_id == exact_id && p.fecha.CompareTo(fecha) == 0 && p.estadoexcursion_id == (int)EstadoExcursion.activa).FirstOrDefault();
                if(calendario == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                if(contexto.calendarioexcursion.Where(p => p.exact_id == exact_id && p.fecha.CompareTo(fechanueva) == 0).FirstOrDefault()!=null)
                {
                    resp.Codigo = (int)Codigos.ERROR_EXISTEN_FECHAS_REPETIDAS;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_EXISTEN_FECHAS_REPETIDAS);
                    resp.Mensaje_error = Errores.error9;
                    return resp.ObjectoRespuesta();
                }
                tran = contexto.Database.BeginTransaction();
                contexto.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, String.Format("UPDATE portalexcursiones.calendarioexcursion SET fecha = '{0}',estadoexcursion_id = {1} where exact_id = {2} and fecha='{3}'", fechanueva.ToString("yyyy/MM/dd HH:mm:ss"),(int)EstadoExcursion.fechamodificada ,exact_id, fecha.ToString("yyyy/MM/dd HH:mm:ss")));
                contexto.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, String.Format("UPDATE portalexcursiones.reservaexcursionactividad SET fecha = '{0}' where exact_id = {1} and fecha='{2}'", fechanueva.ToString("yyyy/MM/dd HH:mm:ss"), exact_id, fecha.ToString("yyyy/MM/dd HH:mm:ss")));
                contexto.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, String.Format("UPDATE portalexcursiones.calendarioexcursion_guia SET fecha = '{0}' where exact_id = {1} and fecha='{2}'", fechanueva.ToString("yyyy/MM/dd HH:mm:ss"), exact_id, fecha.ToString("yyyy/MM/dd HH:mm:ss")));
                contexto.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, String.Format("UPDATE portalexcursiones.calendarioexcursion_puntorecogida SET fecha = '{0}' where exact_id = {1} and fecha='{2}'", fechanueva.ToString("yyyy/MM/dd HH:mm:ss"), exact_id, fecha.ToString("yyyy/MM/dd HH:mm:ss")));
                tran.Commit();
                //enviar emailes a guias,clientes y proveedores para avisarles del cambio de fecha
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                return resp.ObjectoRespuesta();
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

        public HttpResponseMessage AnadirGuia(DateTime fecha, long exact_id, string guia_id)
        {
            try
            {
                if(contexto.calendarioexcursion_guia.Where(x => x.exact_id == exact_id && x.fecha.CompareTo(fecha)==0 && x.guia_id == guia_id).FirstOrDefault() != null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                    return resp.ObjectoRespuesta();
                }
                contexto.calendarioexcursion_guia.Add(new calendarioexcursion_guia() { fecha = fecha, exact_id = exact_id,guia_id = guia_id });
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

        public HttpResponseMessage EliminarGuia(DateTime fecha, long exact_id, string guia_id)
        {
            try
            {
                var guia = contexto.calendarioexcursion_guia.Where(x => x.exact_id == exact_id && x.fecha.CompareTo(fecha) == 0 && x.guia_id == guia_id).FirstOrDefault();
                if(guia == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.calendarioexcursion_guia.Remove(guia);
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

        public HttpResponseMessage AnadirPuntoRecogida(DateTime fecha, long exact_id, int punto_id)
        {
            try
            {
                if (contexto.calendarioexcursion_puntorecogida.Where(x => x.exact_id == exact_id && x.fecha.CompareTo(fecha) == 0 && x.puntorecogida_id == punto_id).FirstOrDefault() != null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                    return resp.ObjectoRespuesta();
                }
                contexto.calendarioexcursion_puntorecogida.Add(new calendarioexcursion_puntorecogida() { fecha = fecha, exact_id = exact_id,puntorecogida_id = punto_id });
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

        public HttpResponseMessage EliminarPuntoRecogida(DateTime fecha, long exact_id, int punto_id)
        {
            try
            {
                var punto = contexto.calendarioexcursion_puntorecogida.Where(x => x.exact_id == exact_id && x.fecha.CompareTo(fecha) == 0 && x.puntorecogida_id == punto_id).FirstOrDefault();
                if(punto == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.calendarioexcursion_puntorecogida.Remove(punto);
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
    }
}