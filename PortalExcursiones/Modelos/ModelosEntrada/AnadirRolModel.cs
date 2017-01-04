using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class RolModel
    {
        private string usuario_id;
        private string rol;

        public string Usuario_id
        {
            get
            {
                return usuario_id;
            }

            set
            {
                usuario_id = value;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }
    }
}