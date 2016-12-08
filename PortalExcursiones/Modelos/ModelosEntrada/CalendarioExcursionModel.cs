using PortalExcursiones.Infraestructura.AtributosValidacion;
using PortalExcursiones.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class CalendarioExcursionModel
    {
        private long exact_id;
        private DateTime desde;
        private DateTime hasta;
        private List<string> horarios;
        private List<string> dias;

        [Fecha(ErrorMessageResourceName = "error13",ErrorMessageResourceType = typeof(ErroresValidacion))]
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

        [Fecha(ErrorMessageResourceName = "error14", ErrorMessageResourceType = typeof(ErroresValidacion))]
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

        [Required(ErrorMessageResourceName = "error15", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [HorariosCalendario()]
        public List<string> Horarios
        {
            get
            {
                return horarios;
            }

            set
            {
                horarios = value;
            }
        }

        [Required(ErrorMessageResourceName = "error16", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [DiasCalendario()]
        public List<string> Dias
        {
            get
            {
                return dias;
            }

            set
            {
                dias = value;
            }
        }

        [Range(1,Double.MaxValue, ErrorMessageResourceName = "error17", ErrorMessageResourceType = typeof(ErroresValidacion))]
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

        public CalendarioExcursionModel() { }
    }
}