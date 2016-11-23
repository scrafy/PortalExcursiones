using System.Net.Http;

namespace PortalExcursiones.Controladores.Interfaces
{
    public interface IOperacionesComunes<T> where T : class
    {
         HttpResponseMessage Crear(T Entidad);
         HttpResponseMessage Actualizar(T Entidad);
         HttpResponseMessage Todos();
         HttpResponseMessage BusquedaPorId(string id);
    }
}
