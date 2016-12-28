﻿using System;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using CapaDatos.Identity;
using CapaDatos;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using PortalExcursiones.Properties;
using System.Linq;
using PortalExcursiones.Infraestructura.Enumeraciones;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class ProveedorOperaciones : IOperacionesComunes<proveedor>
    {
        private AdministradorUsuario mgr = null;
        private Contexto contexto = null;
        private Respuesta resp = null;

        public ProveedorOperaciones(AdministradorUsuario _mgr, Contexto _contexto, Respuesta _resp)
        {
            mgr = _mgr;
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(proveedor Entidad, ModelStateDictionary modelo)
        {
            DbContextTransaction tran = null;
            try
            {
                if (modelo.IsValid)
                {
                    usuario aux = mgr.FindById(Entidad.usuario.Id);
                    if (aux != null)
                    {
                        contexto.Entry(aux).State = EntityState.Detached;
                        Entidad.usuario_id = Entidad.usuario.Id;
                        contexto.Entry(Entidad).State = EntityState.Modified;
                        contexto.Entry(Entidad.usuario).State = EntityState.Modified;
                        tran = contexto.Database.BeginTransaction();
                        Entidad.usuario.PasswordHash = aux.PasswordHash;
                        Entidad.usuario.EmailConfirmed = aux.EmailConfirmed;
                        Entidad.usuario.SecurityStamp = aux.SecurityStamp;
                        Entidad.usuario.PhoneNumberConfirmed = aux.PhoneNumberConfirmed;
                        Entidad.usuario.TwoFactorEnabled = aux.TwoFactorEnabled;
                        Entidad.usuario.LockoutEnabled = aux.LockoutEnabled;
                        Entidad.usuario.LockoutEndDateUtc = aux.LockoutEndDateUtc;
                        Entidad.usuario.AccessFailedCount = aux.AccessFailedCount;
                        IdentityResult result = mgr.Update(Entidad.usuario);
                        if (!result.Succeeded)
                        {
                            if (contexto.Database.CurrentTransaction != null)
                                tran.Rollback();

                            resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                            resp.Objetoerror = result.Errors;
                            return resp.ObjectoRespuesta();
                        }
                        contexto.Entry(Entidad.usuario).State = EntityState.Detached;
                        contexto.SaveChanges();
                        tran.Commit();
                        resp.Codigo = (int)Codigos.OK;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                        return resp.ObjectoRespuesta();
                    }
                    else
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                        resp.Mensaje_error = String.Format(Errores.error1, Entidad.usuario.Id);
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
                if (contexto.Database.CurrentTransaction != null)
                    tran.Rollback();

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
                var cliente = contexto.proveedor.Where(x => x.usuario_id == id).Select(x => new
                {
                    id = x.usuario_id,
                    nombre_empresa = x.nombreempresa,
                    observaciones = x.observaciones,
                    latitud = x.lat,
                    longitud = x.lng,
                    cif = x.cif,
                    direccion1 = x.usuario.direccion1,
                    direccion2 = x.usuario.direccion2,
                    email = x.usuario.Email,
                    telefono = x.usuario.PhoneNumber,
                    nombre = x.usuario.nombre,
                    primerapellido = x.usuario.primerapellido,
                    segundopellido = x.usuario.segundoapellido,
                    localidad = x.usuario.localidad.nombre,
                    codigo_postal = x.usuario.localidad.cp,
                    provincia = x.usuario.localidad.provincia.nombre,
                    pais = x.usuario.localidad.provincia.pais.nombre
                }).FirstOrDefault();

                if (cliente != null)
                {
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    resp.Contenido = cliente;
                    return resp.ObjectoRespuesta();
                }
                else
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    resp.Mensaje_error = String.Format(Errores.error1, id);
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

        public HttpResponseMessage Crear(proveedor Entidad, ModelStateDictionary modelo)
        {
            DbContextTransaction tran = null;
            try
            {
                if (modelo.IsValid)
                {
                    Entidad.usuario_id = Entidad.usuario.Id;
                    tran = contexto.Database.BeginTransaction();
                    IdentityResult result = mgr.CreateAsync(Entidad.usuario, Entidad.usuario.PasswordHash).Result;
                    if (!result.Succeeded)
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
                        contexto.proveedor.Add(Entidad);
                        contexto.SaveChanges();
                        tran.Commit();
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
                if (contexto.Database.CurrentTransaction != null)
                    tran.Rollback();

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
                var clientes = contexto.proveedor.Select(x => new
                {
                    id = x.usuario_id,
                    nombre_empresa = x.nombreempresa,
                    observaciones = x.observaciones,
                    latitud = x.lat,
                    longitud = x.lng,
                    cif = x.cif,
                    direccion1 = x.usuario.direccion1,
                    direccion2 = x.usuario.direccion2,
                    email = x.usuario.Email,
                    telefono = x.usuario.PhoneNumber,
                    nombre = x.usuario.nombre,
                    primerapellido = x.usuario.primerapellido,
                    segundopellido = x.usuario.segundoapellido,
                    localidad = x.usuario.localidad.nombre,
                    codigo_postal = x.usuario.localidad.cp,
                    provincia = x.usuario.localidad.provincia.nombre,
                    pais = x.usuario.localidad.provincia.pais.nombre

                }).ToList();
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = clientes;
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

        public HttpResponseMessage Eliminar(string id)
        {
            throw new NotImplementedException();
        }
    }
}