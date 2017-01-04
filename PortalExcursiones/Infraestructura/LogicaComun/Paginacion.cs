using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Infraestructura.LogicaComun
{
    public class Paginacion
    {
        private int regxpag;
        private Int64 total_registros;
        private int total_paginas;
        private int pag_actual;

        public int Regxpag
        {
            get
            {
                return regxpag;
            }

            set
            {
                regxpag = value;
            }
        }

        public long Total_registros
        {
            get
            {
                return total_registros;
            }

            set
            {
                total_registros = value;
            }
        }

        public int Total_paginas
        {
            get
            {
                return total_paginas;
            }

            set
            {
                total_paginas = value;
            }
        }

        public int Pag_actual
        {
            get
            {
                return pag_actual;
            }

            set
            {
                pag_actual = value;
            }
        }
    }
}