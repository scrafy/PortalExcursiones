using CapaDatos.Entidades;
using System;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using CapaDatos.Identity;
using CapaDatos;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using PortalExcursiones.Infraestructura.Interfaces;
using System.Linq;
using PortalExcursiones.Modelos.ModelosEntrada;
using PortalExcursiones.Properties;
using PortalExcursiones.Infraestructura.Enumeraciones;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Text.RegularExpressions;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class UsuarioOperaciones : IOperacionesComunes<usuario>, IOperacionesUsuario
    {
        private AdministradorUsuario mgr = null;
        private Contexto contexto = null;
        private Respuesta resp = null;
        private IAuthenticationManager auth;

        public UsuarioOperaciones(IAuthenticationManager _auth,AdministradorUsuario _mgr, Contexto _contexto, Respuesta _resp)
        {
            mgr = _mgr;
            contexto = _contexto;
            resp = _resp;
            auth = _auth;
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
                        resp.Mensaje_error = Errores.error2;
                        return resp.ObjectoRespuesta();
                    }
                    else
                    {
                        ClaimsIdentity ident = mgr.CreateIdentityAsync(usuario, DefaultAuthenticationTypes.ApplicationCookie).Result;
                        auth.SignOut();
                        auth.SignIn(new AuthenticationProperties { IsPersistent = true }, ident);
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
            catch (Exception ex)
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
                if (auth.User.Identity.IsAuthenticated)
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
                if (modelo.IsValid)
                {
                    IdentityResult result = mgr.ChangePassword(auth.User.Identity.GetUserId(), password.Passantiguo, password.Passnuevo);
                    if (result.Succeeded)
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
                if (!String.IsNullOrEmpty(email) && Regex.IsMatch(email, "^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$"))
                {
                    usuario usuario = mgr.FindByEmail(email);
                    if (usuario == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = Errores.error4;
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
                    resp.Objetoerror = new string[] { Errores.error5 };
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
                if (modelo.IsValid)
                {
                    IdentityResult result = mgr.ResetPassword(datos.Userid, datos.Token, datos.Password);
                    if (result.Succeeded)
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

        public HttpResponseMessage Crear(usuario Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    IdentityResult result = mgr.Create(Entidad, Entidad.PasswordHash);
                    if(!result.Succeeded)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = result.Errors;
                        return resp.ObjectoRespuesta();
                    }
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

        public HttpResponseMessage Actualizar(usuario Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    var aux = mgr.FindById(Entidad.Id);
                    if(aux == null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                        resp.Mensaje_error = String.Format(Errores.error1,Entidad.Id);
                        return resp.ObjectoRespuesta();
                    }
                    Entidad.PasswordHash = aux.PasswordHash;
                    Entidad.EmailConfirmed = aux.EmailConfirmed;
                    Entidad.SecurityStamp = aux.SecurityStamp;
                    Entidad.PhoneNumberConfirmed = aux.PhoneNumberConfirmed;
                    Entidad.TwoFactorEnabled = aux.TwoFactorEnabled;
                    Entidad.LockoutEnabled = aux.LockoutEnabled;
                    Entidad.LockoutEndDateUtc = aux.LockoutEndDateUtc;
                    Entidad.AccessFailedCount = aux.AccessFailedCount;
                    contexto.Entry(aux).State = EntityState.Detached;
                    contexto.Entry(Entidad).State = EntityState.Modified;
                    IdentityResult result = mgr.Update(Entidad);
                  
                    if(!result.Succeeded)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = result.Errors;
                        return resp.ObjectoRespuesta();
                    }
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

        public HttpResponseMessage BusquedaPorId(string id)
        {
            try
            {
                var usuario = mgr.Users.Where(e => e.Id == id).Select(e => new
                {

                    id = e.Id,
                    direccion1 = e.direccion1,
                    direccion2 = e.direccion2,
                    email = e.Email,
                    telefono = e.PhoneNumber,
                    nombre = e.nombre,
                    primerapellido = e.primerapellido,
                    segundopellido = e.segundoapellido,
                    localidad = e.localidad.nombre,
                    codigo_postal = e.localidad.cp,
                    provincia = e.localidad.provincia.nombre,
                    pais = e.localidad.provincia.pais.nombre
                }).FirstOrDefault();

                if (usuario == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    resp.Mensaje_error = String.Format(Errores.error1, id);
                    return resp.ObjectoRespuesta();
                }
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = usuario;
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
                var usuarios = mgr.Users.Select(e => new
                {

                    id = e.Id,
                    direccion1 = e.direccion1,
                    direccion2 = e.direccion2,
                    email = e.Email,
                    telefono = e.PhoneNumber,
                    nombre = e.nombre,
                    primerapellido = e.primerapellido,
                    segundopellido = e.segundoapellido,
                    localidad = e.localidad.nombre,
                    codigo_postal = e.localidad.cp,
                    provincia = e.localidad.provincia.nombre,
                    pais = e.localidad.provincia.pais.nombre
                }).ToList();

               
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = usuarios;
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