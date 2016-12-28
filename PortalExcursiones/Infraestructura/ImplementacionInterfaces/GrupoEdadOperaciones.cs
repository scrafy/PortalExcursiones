using CapaDatos.Entidades;
using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using CapaDatos;
using PortalExcursiones.Modelos.ModelosSalida;
using PortalExcursiones.Infraestructura.Enumeraciones;
using PortalExcursiones.Properties;
using System.Data.Entity;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class GrupoEdadOperaciones : IOperacionesComunes<grupoedad>, ICreacionMultiple<grupoedad>
    {
        private Contexto contexto;
        private Respuesta resp;

        public GrupoEdadOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(grupoedad Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    string[] listageneros = Enum.GetNames(typeof(NombreRangoEdad));
                    var enviado = Entidad.genero.ToLower();
                    var existe = listageneros.Where(x => x == enviado).FirstOrDefault();
                    if (String.IsNullOrEmpty(existe))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] { Errores.error27 };
                        return resp.ObjectoRespuesta();
                    }
                    var id = Entidad.exact_id;
                    var db = contexto.grupoedad.Where(x => x.exact_id == id && x.genero == enviado && x.id != Entidad.id).FirstOrDefault();
                    if (db != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = String.Format(Errores.error26, db.genero);
                        return resp.ObjectoRespuesta();
                    }
                    contexto.grupoedad.Attach(Entidad);
                    contexto.Entry(Entidad).State = EntityState.Modified;
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
    

        public HttpResponseMessage Crear(List<grupoedad> Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if(modelo.IsValid)
                {
                    var repetidos = (from c in Entidad group c.genero by c.genero.ToLower() into generos select new { key = generos.Key, valores = generos.ToList() }).ToList();
                    foreach(var r in repetidos)
                    {
                        if(r.valores.Count > 1)
                        {
                            resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                            resp.Objetoerror = new string[]{String.Format("El valor {0} aparece más de una vez",r.valores[0])}; 
                            return resp.ObjectoRespuesta();
                        }
                    }
                    string[] listageneros = Enum.GetNames(typeof(NombreRangoEdad));
                    var enviados = (Entidad.Select(x=>x.genero.ToLower())).ToArray();
                    var total = listageneros.Join(enviados, l => l, e => e, (l, e) => l).ToArray().Count();
                    if (total != 5)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[]{Errores.error25};
                        return resp.ObjectoRespuesta();
                    }
                    var id = Entidad[0].exact_id;
                    var db = contexto.grupoedad.Where(x => x.exact_id == id).ToList();
                    var _repetidos = db.Join(Entidad, d => d.genero.ToLower(), e => e.genero.ToLower(), (d, e) => d.genero);
                    if(_repetidos.Count() > 0)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = String.Format(Errores.error26,_repetidos.First());
                        return resp.ObjectoRespuesta();
                    }
                    Entidad.ForEach(x => x.genero = x.genero.ToLower());
                    Entidad.ForEach(x => 
                        contexto.grupoedad.Add(x)
                    );
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

        public HttpResponseMessage Todos()
        {
            try
            {
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = contexto.grupoedad.ToList();
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

        public HttpResponseMessage BusquedaPorId(string id)
        {
            try
            {
                var _id = Int64.Parse(id);
                var grupoedad = contexto.grupoedad.Where(x => x.id == _id).FirstOrDefault();
                if (grupoedad == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    return resp.ObjectoRespuesta();
                }
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                resp.Contenido = grupoedad;
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

        public HttpResponseMessage Crear(grupoedad Entidad, ModelStateDictionary modelo)
        {
            try
            {
                if (modelo.IsValid)
                {
                    string[] listageneros = Enum.GetNames(typeof(NombreRangoEdad));
                    var enviado = Entidad.genero.ToLower();
                    var existe = listageneros.Where(x => x == enviado).FirstOrDefault();
                    if(String.IsNullOrEmpty(existe))
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] { Errores.error27 };
                        return resp.ObjectoRespuesta();
                    }
                    var id = Entidad.exact_id;
                    var db = contexto.grupoedad.Where(x => x.exact_id == id && x.genero == enviado).FirstOrDefault();
                    if (db != null)
                    {
                        resp.Codigo = (int)Codigos.REGISTRO_REPETIDO;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_REPETIDO);
                        resp.Mensaje_error = String.Format(Errores.error26, db.genero);
                        return resp.ObjectoRespuesta();
                    }
                    contexto.grupoedad.Add(Entidad);
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
    }
}