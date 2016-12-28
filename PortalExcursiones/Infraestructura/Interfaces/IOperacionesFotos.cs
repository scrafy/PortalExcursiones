using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesFotos
    {
        HttpResponseMessage Subir(HttpRequestMessage request);
    }
}
