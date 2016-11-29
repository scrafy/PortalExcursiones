using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class CambioPasswordModel
    {
        private string passantiguo;
        private string passnuevo; 

        public CambioPasswordModel()
        {

        }

        public string Passantiguo
        {
            get
            {
                return passantiguo;
            }

            set
            {
                passantiguo = value;
            }
        }

        public string Passnuevo
        {
            get
            {
                return passnuevo;
            }

            set
            {
                passnuevo = value;
            }
        }
    }
}