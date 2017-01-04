using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Linq;
using CapaDatos.Entidades;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using PortalExcursiones.Modelos.ModelosSalida;
using PortalExcursiones.Infraestructura.Enumeraciones;
using CapaDatos;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class FotoConfiguracionOperaciones : Operaciones, IOperacionesComunes<fotoconfiguracion>, IOperacionesFotoConfiguracion
    {
        private Contexto contexto;
        private Respuesta resp;

        public FotoConfiguracionOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(fotoconfiguracion Entidad, ModelStateDictionary modelo)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage BusquedaPorId(string id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var _id = Int64.Parse(id);
                var foto = contexto.fotoconfiguracion.Where(x => x.id == _id && x.configuracion.proveedor_id == proveedor_id).Select(x => new { id = x.id, nombre = x.nombre,url = x.url,configuracion_id = x.configuracion_id }).FirstOrDefault();
                if (foto == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = foto;
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

        public HttpResponseMessage Crear(fotoconfiguracion Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    contexto.fotoconfiguracion.Add(Entidad);
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

        public HttpResponseMessage Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Eliminar(long id)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var foto = contexto.fotoconfiguracion.Where(x => x.id == id && x.configuracion.proveedor_id == proveedor_id).FirstOrDefault();
                if(foto == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.fotoconfiguracion.Remove(foto);
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

        public HttpResponseMessage Todos(int pag_actual, int regxpag)
        {
            try
            {
                var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                var _fotos = contexto.fotoconfiguracion.Include("configuracion").Where(x => x.configuracion.proveedor_id == proveedor_id).OrderBy(x => x.id).Skip((pag_actual - 1) * regxpag).Take(regxpag).ToList();
                var fotos = _fotos.Select(x => new { id = x.id, nombre = x.nombre, url = x.url, configuracion_id = x.configuracion_id, confnombre = x.configuracion.nombre }).GroupBy(x => x.confnombre);
                var output = new Dictionary<string, List<dynamic>>();
                List<dynamic> listafotos = null;
                foreach (var foto in fotos)
                {
                    listafotos = new List<dynamic>();
                    foreach (var f in foto)
                    {
                        listafotos.Add(f);
                    }
                    output.Add(foto.Key, listafotos);
                }
                var paginacion = this.Paginacion(contexto.fotoconfiguracion.Where(x => x.configuracion.proveedor_id == proveedor_id).Count(), pag_actual, regxpag);
                var result = new
                {
                    fotos = output,
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
    }
}