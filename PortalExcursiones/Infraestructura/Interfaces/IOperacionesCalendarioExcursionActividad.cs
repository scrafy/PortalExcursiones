using PortalExcursiones.Modelos.ModelosEntrada;
using System;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesCalendarioExcursionActividad
    {
        HttpResponseMessage Crear(CalendarioExcursionModel datos, ModelStateDictionary modelo);
        HttpResponseMessage Eliminar(DateTime fecha, long exact_id);
        HttpResponseMessage Actualizar(DateTime fecha, DateTime fechanueva, long exact_id);
        HttpResponseMessage AnadirGuia(DateTime fecha, long exact_id,string guia_id);
        HttpResponseMessage EliminarGuia(DateTime fecha, long exact_id, string guia_id);
        HttpResponseMessage AnadirPuntoRecogida(DateTime fecha, long exact_id, int punto_id);
        HttpResponseMessage EliminarPuntoRecogida(DateTime fecha, long exact_id, int punto_id);
    }
}