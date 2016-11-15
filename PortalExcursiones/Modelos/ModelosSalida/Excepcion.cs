using System;


namespace PortalExcursiones.Modelos.ModelosSalida
{
    public class Excepcion
    {
        private string mensaje;
        private string trazapila;
        private string fuente;

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

        public string TrazaPila
        {
            get
            {
                return trazapila;
            }

            set
            {
                trazapila = value;
            }
        }

        public string Fuente
        {
            get
            {
                return fuente;
            }

            set
            {
                fuente = value;
            }
        }

        private Exception ObtenerMensaje(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return this.ObtenerMensaje(ex.InnerException);
            }
            else
                return ex;
        }

        public Excepcion()
        {

        }

        public static Excepcion Create(Exception ex)
        {
            if (ex == null)
                return null;

            Excepcion exepcion = new Excepcion();
            Exception _ex = exepcion.ObtenerMensaje(ex);
            exepcion.TrazaPila = _ex.StackTrace;
            exepcion.Mensaje = _ex.Message;
            exepcion.Fuente = _ex.Source;
            return exepcion;
        }
    }
}