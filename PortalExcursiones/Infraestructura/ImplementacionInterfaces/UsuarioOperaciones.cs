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
using System.Net.Http.Headers;
using System.Configuration;
using PortalExcursiones.Infraestructura.LogicaComun;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class UsuarioOperaciones : Operaciones,IOperacionesComunes<usuario>, IOperacionesUsuario
    {
        private AdministradorUsuario mgr = null;
        private Contexto contexto = null;
        private Respuesta resp = null;
        private IAuthenticationManager auth;
        private GestionAvisosEmail avisosemail = null;

        public UsuarioOperaciones(IAuthenticationManager _auth,AdministradorUsuario _mgr, Contexto _contexto, Respuesta _resp,GestionAvisosEmail avisos)
        {
            mgr = _mgr;
            contexto = _contexto;
            resp = _resp;
            auth = _auth;
            avisosemail = avisos;
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
                bool autenticado = HttpContext.Current.User.Identity.IsAuthenticated;
                bool isinrole = HttpContext.Current.User.IsInRole("cliente");
                
                if (modelo.IsValid)
                {
                    if(password.Passnuevo != password.Confpassnuevo)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[]{ErroresValidacion.error31};
                        return resp.ObjectoRespuesta();
                    }
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

        /*  public HttpResponseMessage ObtenerTokenReseteoPassword(string email)
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
                      avisosemail.ResetPassword(usuario.Id, token);
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
          }*/

        /* public HttpResponseMessage RenovarPassword(RenovacionPasswordModel datos, ModelStateDictionary modelo)
         {
             try
             {
                 if(modelo.IsValid)
                 {
                     datos.Token = datos.Token.Replace(" ", "+");
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
         }*/

        public HttpResponseMessage ResetPassword(string email)
        {
            try
            {
                var user = mgr.FindByEmail(email);
                if (user == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    resp.Mensaje_error = Errores.error4;
                    return resp.ObjectoRespuesta();
                }
                var newpassword = NewPassword();
                var aux = mgr.PasswordHasher.HashPassword(newpassword);
                user.PasswordHash = aux;
                IdentityResult result = mgr.Update(user);
                if (result.Succeeded)
                {
                    Task.Run(() => avisosemail.ResetPassword(user.Id, newpassword));
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
            catch (Exception ex)
            {
                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
        }

        private string NewPassword()
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            string output = "";
            for (int i = 0; i < data.Length; i++)
            {
                output += data[i].ToString("X2");
            }
            return output.Substring(0, 10);
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

        public HttpResponseMessage Todos(int pag_actual,int regxpag)
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
                    pais = e.localidad.provincia.pais.nombre,
                   
                }).OrderBy(x => x.nombre).Skip((pag_actual - 1) * regxpag).Take(regxpag).ToList();
                var paginacion = this.Paginacion(mgr.Users.Count(), pag_actual, regxpag);
                var result = new
                {
                    usuarios = usuarios,
                    paginacion  = paginacion
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

        public HttpResponseMessage CambiarIdioma(string idioma)
        {
            if(Regex.IsMatch(idioma, ConfigurationManager.AppSettings["regexidiomas"]))
            {
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                HttpResponseMessage msg = resp.ObjectoRespuesta();
                CookieHeaderValue coo = new CookieHeaderValue("idioma", idioma);
                coo.Path = "/";
                msg.Headers.AddCookies(new CookieHeaderValue[]{coo});
                return msg;
            }
            else
            {
                resp.Codigo = (int)Codigos.ERROR_CODIGO_IDIOMA_INCORRECTO;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_CODIGO_IDIOMA_INCORRECTO);
                return resp.ObjectoRespuesta();
            }
           
        }

        public HttpResponseMessage Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage AnadirRol(RolModel datos)
        {
            try
            {
               IdentityResult result = mgr.AddToRole(datos.Usuario_id, datos.Rol);
               if(!result.Succeeded)
               {
                    resp.Codigo = (int)Codigos.ERROR_AÑADIENDO_ROL;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_AÑADIENDO_ROL);
                    resp.Objetoerror = result.Errors;
                    return resp.ObjectoRespuesta();
               }
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

        public HttpResponseMessage EliminarRol(RolModel datos)
        {
            try
            {
                IdentityResult result = mgr.RemoveFromRole(datos.Usuario_id, datos.Rol);
                if (!result.Succeeded)
                {
                    resp.Codigo = (int)Codigos.ERROR_AÑADIENDO_ROL;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_AÑADIENDO_ROL);
                    resp.Objetoerror = result.Errors;
                    return resp.ObjectoRespuesta();
                }
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