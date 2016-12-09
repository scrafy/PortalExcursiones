using System.Net.Http;


namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesExcursionActividad
    {
        HttpResponseMessage AnadirItem(long item_id, long exact_id);
        HttpResponseMessage EliminarItem(long item_id, long exact_id);
    }
}
