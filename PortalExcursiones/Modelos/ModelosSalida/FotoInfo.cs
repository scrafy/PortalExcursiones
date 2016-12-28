using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosSalida
{
    public class FotoInfo
    {
        private string nombre;
        private string url;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
    }
}