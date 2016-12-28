using System.Net.Http;
using CapaDatos.Entidades;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesFotoConfiguracion
    {
         HttpResponseMessage Eliminar(long id);
       
    }
}
