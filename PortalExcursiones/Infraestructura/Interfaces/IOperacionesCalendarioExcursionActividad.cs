using PortalExcursiones.Modelos.ModelosEntrada;
using System;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesCalendarioExcursionActividad
    {
        HttpResponseMessage Crear(CalendarioExcursionModel datos, ModelStateDictionary modelo);
        HttpResponseMessage Eliminar(CalendarioExcursionActualizarEliminarModel datos, ModelStateDictionary modelo);
        HttpResponseMessage Actualizar(CalendarioExcursionActualizarEliminarModel datos, ModelStateDictionary modelo);
      
    }
}