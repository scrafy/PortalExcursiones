using PortalExcursiones.Modelos.ModelosEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesPuntoRecogida
    {
        HttpResponseMessage Crear(PuntoRecogidaModel datos, ModelStateDictionary modelo);
        HttpResponseMessage Actualizar(PuntoRecogidaModel datos, ModelStateDictionary modelo);
        HttpResponseMessage BusquedaPorId(long id);
        HttpResponseMessage BusquedaPorExAct(long id);
        HttpResponseMessage Todos(int pag_Actual,int regxpag);
        HttpResponseMessage Eliminar(long id);
    }
}
