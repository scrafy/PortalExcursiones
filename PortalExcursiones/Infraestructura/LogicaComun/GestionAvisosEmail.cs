using CapaDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PortalExcursiones.Infraestructura.LogicaComun
{
    public class GestionAvisosEmail
    {
        public static void PuntoRecogidaEliminado(long id,Contexto contexto)
        {
            var now = DateTime.UtcNow;
            var direcciones = contexto.reservaexcursionactividad.Where(x => x.punto_id == id && x.calendarioexcursion.fecha >= now).Select(x => x.reserva.cliente.usuario.Email).ToList();
            foreach (var direccion in direcciones)
            {
                //enviar email a todos los clientes que tiene reservas futuras con este punto de recogida
            }
        }

        public static void PuntoRecogidaModificado(long id, Contexto contexto)
        {
            var now = DateTime.UtcNow;
            var direcciones = contexto.reservaexcursionactividad.Where(x => x.punto_id == id && x.calendarioexcursion.fecha >= now).Select(x => x.reserva.cliente.usuario.Email).ToList();
            foreach (var direccion in direcciones)
            {
                //enviar email a todos los clientes que tiene reservas futuras con este punto de recogida
            }
        }

        public static void ExActAnulada(long id,DateTime fecha,Contexto contexto)
        {
            var direcciones = contexto.reservaexcursionactividad.Where(x => x.calendario_id == id).Select(x => x.reserva.cliente.usuario.Email).ToList();
            foreach (var direccion in direcciones)
            {
                //enviar email a todos los clientes que la excursion ha sido anulada
            }
        }

        public static void EnviarFacturaReserva(long id, Contexto contexto)
        {
            var datos = contexto.reservaexcursionactividad.Where(x => x.reserva_id == id).Select(x => new
            {
                emailclient = x.reserva.cliente.usuario.Email,
                emailproveedor = x.reserva.proveedor.usuario.Email,
                factura = x.reserva.factura,
                enviaremailproveedor = x.reserva.proveedor.emailfactura

            }).First();
            string filePath = HostingEnvironment.MapPath("~/" + ConfigurationManager.AppSettings["directoriofacturas"] + "/" + datos.factura);
            if(datos.enviaremailproveedor)
            {
                //enviar email a proveedor con factura adjunta
            }
            //enviar email a cliente con factura adjunta
        }

        public static void FechaCalendarioModificada(long id, DateTime fecha,Contexto contexto)
        {
            var direcciones = contexto.reservaexcursionactividad.Where(x => x.calendario_id == id).Select(x => x.reserva.cliente.usuario.Email).ToList<string>();
            foreach (var direccion in direcciones)
            {
                //enviar email a todos los clientes que la excursion ha sido anulada
            }
        }
    }
}