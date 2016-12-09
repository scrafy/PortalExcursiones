using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class AnadirEliminarIdiomaModel
    {
        private string guia_id;
        private int idioma_id;

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

        public int Idioma_id
        {
            get
            {
                return idioma_id;
            }

            set
            {
                idioma_id = value;
            }
        }
    }
}