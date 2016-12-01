using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalExcursiones.Modelos.ModelosEntrada;
using System.Net.Http;
using Microsoft.Owin.Security;
using System.Security.Claims;
using CapaDatos.Identity;
using CapaDatos.Entidades;
using Microsoft.AspNet.Identity;
using System.Web.Http.ModelBinding;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Web.Http;
using System.Text.RegularExpressions;
using PortalExcursiones.Properties;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class UsuarioOperaciones : IOperacionesUsuario
    {
        private IAuthenticationManager auth;
        private AdministradorUsuario mgr;
        private Respuesta resp;

        public UsuarioOperaciones(IAuthenticationManager _auth,AdministradorUsuario _mgr,Respuesta _resp)
        {
            auth = _auth;
            mgr = _mgr;
            resp = _resp;
        }

        
        public HttpResponseMessage Login(LoginModel login, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    usuario usuario = mgr.FindAsync(login.Username, login.Password).Result;
                    if (usuario == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = String.Format(Errores.error2);
                        return resp.ObjectoRespuesta();
                    }
                    else
                    {
                        ClaimsIdentity ident =  mgr.CreateIdentityAsync(usuario,DefaultAuthenticationTypes.ApplicationCookie).Result;
                        auth.SignOut();
                        auth.SignIn(new AuthenticationProperties{IsPersistent = true}, ident);
                        resp.Codigo = (int)Codigos.OK;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                        return resp.ObjectoRespuesta();
                    }
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

        
        public HttpResponseMessage Logout()
        {
            try
            {
                if(auth.User.Identity.IsAuthenticated)
                {
                    auth.SignOut();
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    return resp.ObjectoRespuesta();
                }
                resp.Codigo = (int)Codigos.NO_AUTENTICADO;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.NO_AUTENTICADO);
                resp.Mensaje_error = Errores.error3;
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

        public HttpResponseMessage CambiarPassword(CambioPasswordModel password, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    IdentityResult result = mgr.ChangePassword(auth.User.Identity.GetUserId(), password.Passantiguo, password.Passnuevo);
                    if(result.Succeeded)
                    {
                        resp.Codigo = (int)Codigos.OK;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                        return resp.ObjectoRespuesta();
                    }
                    resp.Mensaje_error = result.Errors.First();
                    resp.Codigo = (int)Codigos.ERROR_CAMBIO_PASSWORD;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_CAMBIO_PASSWORD);
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

        public HttpResponseMessage ObtenerTokenReseteoPassword(string email)
        {
            try
            {
                if(!String.IsNullOrEmpty(email) && Regex.IsMatch(email, "^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$"))
                {
                    usuario usuario = mgr.FindByEmail(email);
                    if(usuario==null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = String.Format(Errores.error4);
                        return resp.ObjectoRespuesta();
                    }
                    var token = mgr.GeneratePasswordResetToken(usuario.Id);
                    mgr.SendEmail(usuario.Id, Mensajes.mensaje1, String.Format("http://localhost:54656/api/usuarios/renovarpassword?userid={0}&token={1}", usuario.Id, token));
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    return resp.ObjectoRespuesta();
                }
                else
                {
                    resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                    resp.Objetoerror = new string[] {Errores.error5};
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

        public HttpResponseMessage RenovarPassword(RenovacionPasswordModel datos, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    IdentityResult result = mgr.ResetPassword(datos.Userid, datos.Token, datos.Password);
                    if(result.Succeeded)
                    {
                        resp.Codigo = (int)Codigos.OK;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                        return resp.ObjectoRespuesta();
                    }
                    else
                    {
                        resp.Codigo = (int)Codigos.ERROR_RESETEANDO_PASSWORD;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_RESETEANDO_PASSWORD);
                        resp.Mensaje_error = result.Errors.First();
                        return resp.ObjectoRespuesta();
                    }
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
    }
}