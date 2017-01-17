using CapaDatos.Infraestructura.Json;
using Newtonsoft.Json;
using PortalExcursiones.CapaDatos.Infraestructura.AtributosValidacion;
using PortalExcursiones.Properties;
using System;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class ClientesReserva
    {
        private DateTime desde;
        private DateTime hasta;

        [Fecha(ErrorMessage ="error13",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Desde
        {
            get
            {
                return desde;
            }

            set
            {
                desde = value;
            }
        }
        [Fecha(ErrorMessage = "error14", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Hasta
        {
            get
            {
                return hasta;
            }

            set
            {
                hasta = value;
            }
        }
    }
    
}