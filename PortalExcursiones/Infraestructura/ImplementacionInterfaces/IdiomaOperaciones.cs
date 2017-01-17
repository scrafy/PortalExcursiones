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
    public class IdiomaOperaciones : IOperacionesComunes<idioma>
    {

        private Contexto contexto;
        private Respuesta resp;

        public IdiomaOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }


        public HttpResponseMessage Actualizar(idioma Entidad, ModelStateDictionary modelo)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage BusquedaPorId(string id)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Crear(idioma Entidad, ModelStateDictionary modelo)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Eliminar(string id)
        {
            try
            {
                long _id = Int64.Parse(id);
                var idioma = contexto.idioma.Find(_id);
                if (idioma == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                contexto.idioma_exact.Where(x => x.idioma_id == _id).ToList().ForEach(x => contexto.idioma_exact.Remove(x));
                contexto.idioma.Remove(idioma);
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
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = contexto.idioma.Select(x => new { id = x.id, nombre = x.lenguage }).ToList();
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