using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesGuia
    {
        HttpResponseMessage AnadirIdioma(int idioma_id, string guia_id);
        HttpResponseMessage EliminarIdioma(int idioma_id,string guia_id);
    }
}
