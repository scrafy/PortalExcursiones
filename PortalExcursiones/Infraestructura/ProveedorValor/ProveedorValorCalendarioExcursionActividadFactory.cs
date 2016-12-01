using Newtonsoft.Json;
using PortalExcursiones.Infraestructura.ProveedorValor;
using PortalExcursiones.Modelos.ModelosEntrada;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace PortalExcursiones.Infraestructura.ProveedorValor
{
    public class ProveedorValorCalendarioExcursionActividad : IValueProvider
    {
        private HttpActionContext contexto;


        public ProveedorValorCalendarioExcursionActividad(HttpActionContext _contexto)
        {
            contexto = _contexto;
        }


        public bool ContainsPrefix(string prefix)
        {
            return false;
        }

        public ValueProviderResult GetValue(string key)
        {
            string contenido = contexto.Request.Content.ReadAsStringAsync().Result;
            CalendarioExcursionModel aux = JsonConvert.DeserializeObject<CalendarioExcursionModel>(contenido);
            aux.Dias = aux.Dias.ConvertAll(d => d.ToLower());
            DateTime dt = new DateTime();
            if(DateTime.TryParse(aux.Desde.ToString(), CultureInfo.GetCultureInfo("en-ES"), DateTimeStyles.None, out dt))
            {
                aux.Desde = dt;
                if(DateTime.TryParse(aux.Hasta.ToString(), CultureInfo.GetCultureInfo("en-ES"), DateTimeStyles.None, out dt))
                {
                    aux.Hasta = dt;
                    return new ValueProviderResult(aux, contenido, CultureInfo.InvariantCulture);
                }
            }
            return null;
        }
    }

    public class ProveedorValorCalendarioExcursionActividadFactory : ValueProviderFactory
    {

        public override IValueProvider GetValueProvider(HttpActionContext contexto)
        {
            return new ProveedorValorCalendarioExcursionActividad(contexto);
        }
    }
}