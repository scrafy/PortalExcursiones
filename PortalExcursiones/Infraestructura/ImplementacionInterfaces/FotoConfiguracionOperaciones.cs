using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Linq;
using CapaDatos.Entidades;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using PortalExcursiones.Modelos.ModelosSalida;
using PortalExcursiones.Infraestructura.Enumeraciones;
using CapaDatos;


namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class FotoConfiguracionOperaciones : IOperacionesComunes<fotoconfiguracion>, IOperacionesFotoConfiguracion
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
                var _id = Int64.Parse(id);
                var foto = contexto.fotoconfiguracion.Where(x => x.id == _id).Select(x => new { id = x.id, nombre = x.nombre,url = x.url,configuracion_id = x.configuracion_id }).FirstOrDefault();
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
                var foto = contexto.fotoconfiguracion.Where(x => x.id == id).FirstOrDefault();
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

        public HttpResponseMessage Todos()
        {
            try
            {
                var fotos = contexto.fotoconfiguracion.Select(x => new { id = x.id, nombre = x.nombre, url = x.url, configuracion_id = x.configuracion_id });
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = fotos;
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