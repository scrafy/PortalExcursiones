using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Modelos.ModelosSalida
{
    public class Respuesta
    {
        private int codigo;
        private string mensaje;
        private string mensaje_error;
        private List<string> erroresvalidacion = null;
        private Excepcion excepcion = null;
        private object contenido = null;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Mensaje
        {
            get
            {
                return mensaje;
            }

            set
            {
                mensaje = value;
            }
        }

        public string Mensaje_error
        {
            get
            {
                return mensaje_error;
            }

            set
            {
                mensaje_error = value;
            }
        }

        public List<string> Erroresvalidacion
        {
            get
            {
                return erroresvalidacion;
            }

            set
            {
                erroresvalidacion = value;
            }
        }

        public Excepcion Excepcion
        {
            get
            {
                return excepcion;
            }

            set
            {
                excepcion = value;
            }
        }

        public object Contenido
        {
            get
            {
                return contenido;
            }

            set
            {
                contenido = value;
            }
        }

        public static List<string> ObtenerErroresValidacion(ModelStateDictionary modelstate)
        {

            if (modelstate==null)
                return null;

            List<string> errores = new List<string>();
            foreach (ModelState m in modelstate.Values)
            {
                foreach (ModelError e in m.Errors)
                {
                   errores.Add(e.ErrorMessage);
                }
            }
            return errores;

        }

        public Respuesta()
        {

        }

       
    }
    
}