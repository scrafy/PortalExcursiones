using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosSalida.Errores
{
    public class ErrorGenerico
    {
        private string message;
        private string stackTrace;
        private string source;

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public string StackTrace
        {
            get
            {
                return stackTrace;
            }

            set
            {
                stackTrace = value;
            }
        }

        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }

        private Exception GetMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
               return this.GetMessage(ex.InnerException);
            }
            else
                return ex;
        }
        
        public ErrorGenerico(Exception ex)
        {
            Exception _ex = this.GetMessage(ex);
            this.StackTrace = _ex.StackTrace;
            this.Message = _ex.Message;
            this.Source = _ex.Source;

        }
    }
}