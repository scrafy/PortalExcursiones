using CapaDatos.Infraestructura.Json;
using Newtonsoft.Json;
using PortalExcursiones.Infraestructura.AtributosValidacion;
using PortalExcursiones.Properties;
using System;


namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class CalendarioExcursionActualizarEliminarModel
    {
        private DateTime fecha;
        private DateTime fechanueva;
        private long exact_id;
        private string motivoanulacion;

        [Hora(ErrorMessageResourceName = "error12",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [Fecha(ErrorMessageResourceName = "error28", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        [Hora(ErrorMessageResourceName = "error12", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [Fecha(ErrorMessageResourceName = "error29", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Fechanueva
        {
            get
            {
                return fechanueva;
            }

            set
            {
                fechanueva = value;
            }
        }

        public long Exact_id
        {
            get
            {
                return exact_id;
            }

            set
            {
                exact_id = value;
            }
        }
        public string Motivoanulacion
        {
            get
            {
                return motivoanulacion;
            }

            set
            {
                motivoanulacion = value;
            }
        }
    }
}