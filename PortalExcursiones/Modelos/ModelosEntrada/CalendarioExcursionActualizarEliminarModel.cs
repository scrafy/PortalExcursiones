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

        [Hora(ErrorMessageResourceName = "error12",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [Fecha(ErrorMessageResourceName = "error28", ErrorMessageResourceType = typeof(ErroresValidacion))]
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
    }
}