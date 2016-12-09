using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class CalendarioExcursionActualizarEliminarModel
    {
        private DateTime fecha;
        private DateTime fechanueva;
        private long exact_id;

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