using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class GuiaFechaModel
    {
        private long exact_id;
        private DateTime fecha;
        private string guia_id;

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

        public string Guia_id
        {
            get
            {
                return guia_id;
            }

            set
            {
                guia_id = value;
            }
        }
    }
}