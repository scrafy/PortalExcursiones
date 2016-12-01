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
                if(modelo.IsValid)
                {
                    return null;
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
    }
}