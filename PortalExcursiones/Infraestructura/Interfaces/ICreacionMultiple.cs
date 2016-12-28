using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface ICreacionMultiple<T> where T : class
    {
        HttpResponseMessage Crear(List<T> Entidad, ModelStateDictionary modelo);
    }
}
