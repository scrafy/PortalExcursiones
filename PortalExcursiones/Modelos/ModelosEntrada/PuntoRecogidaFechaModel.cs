using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class PuntoRecogidaFechaModel
    {
        private long exact_id;
        private DateTime fecha;
        private int punto_id;

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

        public int Punto_id
        {
            get
            {
                return punto_id;
            }

            set
            {
                punto_id = value;
            }
        }
    }
}