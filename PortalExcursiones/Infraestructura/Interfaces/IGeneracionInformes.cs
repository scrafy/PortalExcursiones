using PortalExcursiones.Modelos.ModelosEntrada;
using System.Web.Http.ModelBinding;
using System.Net.Http;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IGeneracionInformes
    {
        HttpResponseMessage Reservas(ClientesReserva fechas, ModelStateDictionary modelo,int pag_actual,int regxpag);
    }
}
