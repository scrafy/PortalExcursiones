using System;
using CapaDatos;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Web.Http.ModelBinding;
using System.Linq;
using PortalExcursiones.Infraestructura.Enumeraciones;
using System.Net.Http;
using System.Web;
using Microsoft.AspNet.Identity;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class ConsultaOperaciones : Operaciones,IGeneracionInformes
    {
        private Contexto contexto;
        private Respuesta resp;

        public ConsultaOperaciones(Contexto _contexto, Respuesta _resp)
        {
            contexto = _contexto;
            resp = _resp;
        }


        public HttpResponseMessage Reservas(ClientesReserva fechas, ModelStateDictionary modelo,int pag_actual,int regxpag)
        {
            try
            {
                if(modelo.IsValid)
                {
                    var proveedor_id = HttpContext.Current.User.Identity.GetUserId();
                    var reservas =
                    (
                        from r in contexto.reservaexcursionactividad
                        join f in contexto.calendarioexcursion on r.calendario_id equals f.id
                        where (fechas.Desde <= f.fecha && f.fecha <= fechas.Hasta) && f.estadoexcursion_id == 1 && r.reserva.proveedor_id == proveedor_id
                        select new
                        {
                            id = r.reserva.id,
                            fechatransaccion = r.reserva.fechatransaccion,
                            precio = r.reserva.precio,
                            factura = r.reserva.factura,
                            codigoqr = r.reserva.codigoqr,
                            numadultos = r.numadultos,
                            numjuniors = r.numjuniors,
                            numseniors = r.numseniors,
                            numninos = r.numninos,
                            numinfantes = r.numinfantes,
                            fechaexcursion = f.fecha,
                            puntorecogida = (r.punto.nombre == null) ? null : new
                            {
                                nombre = r.punto.nombre,
                                lat = r.punto.lat,
                                lng = r.punto.lng,
                                direccion = r.punto.direccion,
                                descripcion = r.punto.descripcion,
                                localidad = r.punto.localidad.nombre,
                                codigo_postal = r.punto.localidad.cp,
                                provincia = r.punto.localidad.provincia.nombre,
                                pais = r.punto.localidad.provincia.pais.nombre
                            },
                            cliente = new
                            {
                                nombre = r.reserva.cliente.usuario.nombre,
                                primerapellido = r.reserva.cliente.usuario.primerapellido,
                                segundoapellido = r.reserva.cliente.usuario.segundoapellido,
                                email = r.reserva.cliente.usuario.Email,
                                telefono = r.reserva.cliente.usuario.PhoneNumber,
                                hotel = r.nombrehotel,
                                direccionhotel = r.direccion,
                                observaciones = r.observaciones,
                                localidad = r.localidad.nombre,
                                codigo_postal = r.localidad.cp,
                                provincia = r.localidad.provincia.nombre,
                                pais = r.localidad.provincia.pais.nombre
                            }

                       }
                    ).OrderBy(x => x.fechatransaccion).Skip((pag_actual - 1) * regxpag).Take(regxpag).ToList();
                    var paginacion = this.Paginacion(contexto.reservaexcursionactividad.Where(x => (fechas.Desde <= x.calendarioexcursion.fecha && x.calendarioexcursion.fecha <= fechas.Hasta) && x.calendarioexcursion.estadoexcursion_id == 1 && x.reserva.proveedor_id == proveedor_id).Count(), pag_actual, regxpag);
                    var result = new
                    {
                        reservas = reservas,
                        paginacion = paginacion
                    };
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    resp.Contenido = result;
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