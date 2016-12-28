using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesComunes<T> where T : class
    {
         HttpResponseMessage Crear(T Entidad,ModelStateDictionary modelo);
         HttpResponseMessage Actualizar(T Entidad, ModelStateDictionary modelo);
         HttpResponseMessage Todos();
         HttpResponseMessage BusquedaPorId(string id);
         HttpResponseMessage Eliminar(string id);
    }
}
