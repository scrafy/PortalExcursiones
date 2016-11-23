using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using PortalExcursiones.Controladores.Interfaces;
using CapaDatos.Identity;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using CapaDatos;
using CapaDatos.Entidades;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace PortalExcursiones.Controladores.ImplementacionInterfaces
{
    public class ClienteServicios : IOperacionesComunes<cliente>
    {
        private AdministradorUsuario mgr = null;
        private Contexto contexto = null;
        private Respuesta resp = null;
        private ModelStateDictionary modelo = null;

        public ClienteServicios(AdministradorUsuario _mgr, Contexto _contexto,Respuesta _resp)
        {
            mgr = _mgr; 
            contexto = _contexto;
            resp = _resp;
            
        }

        public ClienteServicios()
        { }

        public HttpResponseMessage Crear(cliente Entidad)
        {
            DbContextTransaction tran = null;
            try
            {
                //if(modelo.IsValid)
               // {
                    Entidad.usuario_id = Entidad.usuario.Id;
                    tran = contexto.Database.BeginTransaction();
                    IdentityResult result = mgr.CreateAsync(Entidad.usuario, Entidad.usuario.PasswordHash).Result;
                    if(!result.Succeeded)
                    {
                        if (contexto.Database.CurrentTransaction != null)
                            tran.Rollback();

                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = result.Errors;
                        return resp.ObjectoRespuesta();

                    }
                    else
                    {
                        Entidad.usuario = null;
                        contexto.cliente.Add(Entidad);
                        contexto.SaveChanges();
                        tran.Commit();
                        resp.Codigo = (int)Codigos.OK;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                        return resp.ObjectoRespuesta();
                    }

               /* }
                else
                {
                    resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                    resp.Objetoerror = modelo;
                    return resp.ObjectoRespuesta();
                }*/
            }
            catch(Exception ex)
            {
                if(contexto.Database.CurrentTransaction != null)
                    tran.Rollback();

                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
           
        }

        public HttpResponseMessage Actualizar(cliente Entidad)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Todos()
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage BusquedaPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
    
}