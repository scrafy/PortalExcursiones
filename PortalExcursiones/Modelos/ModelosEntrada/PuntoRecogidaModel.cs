using PortalExcursiones.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class PuntoRecogidaModel
    {
        private long id;
        private string nombre;
        private string lat;
        private string lng;
        private string direccion;
        private string descripcion;
        private long localidad_id;
        
        [Required(ErrorMessageResourceName = "error24", ErrorMessageResourceType = typeof(ErroresValidacion))]
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

        [Required(ErrorMessageResourceName = "error25", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Lat
        {
            get
            {
                return lat;
            }

            set
            {
                lat = value;
            }
        }

        [Required(ErrorMessageResourceName = "error26", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Lng
        {
            get
            {
                return lng;
            }

            set
            {
                lng = value;
            }
        }
        [Required(ErrorMessageResourceName = "error27", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public long Localidad_id
        {
            get
            {
                return localidad_id;
            }

            set
            {
                localidad_id = value;
            }
        }

        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}