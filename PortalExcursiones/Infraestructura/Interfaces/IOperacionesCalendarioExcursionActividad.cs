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
    }
}
