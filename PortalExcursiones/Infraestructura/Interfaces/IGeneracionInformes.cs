using CapaDatos.Entidades;
using CapaDatos;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IGeneracionInformes
    {
        void GenerarFactura(Contexto contexto, string id);
    }
}
