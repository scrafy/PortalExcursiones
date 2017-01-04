using PortalExcursiones.Modelos.ModelosEntrada;
using System.Collections.Generic;
using System.Net.Http;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesExcursionActividad
    {
        HttpResponseMessage AnadirItem(long item_id, long exact_id);
        HttpResponseMessage EliminarItem(long item_id, long exact_id);
        HttpResponseMessage AnadirIdioma(List<IdiomaExActModel> idiomas);
        HttpResponseMessage EliminarIdioma(int idioma_id,long exact_id);
        HttpResponseMessage AnadirItemFactura(List<FacturaItemModel> items);
        HttpResponseMessage EliminarItemFactura(long item_id, long exact_id);
        HttpResponseMessage AnadirPunto(List<PuntoModel> puntos);
        HttpResponseMessage EliminarPunto(PuntoModel punto);
        HttpResponseMessage GrupoEdad(long exact_id);
    }
}
