using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Modelos.ModelosSalida
{
    public class Respuesta
    {
        private int codigo;
        private string mensaje = null;
        private string mensaje_error = null;
        private Object errores = null;
        private List<string> erroresvalidacion = null;
        private Excepcion excepcion = null;
        private object contenido = null;
        private string mime = "application/json";

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

        [JsonIgnore]
        public Object Errores
        {
            get
            {
                return errores;
            }

            set
            {
               if(value.GetType() == typeof(ModelStateDictionary))
                    Erroresvalidacion = ModelStateErrores((ModelStateDictionary)value);
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
        [JsonIgnore]
        public string Mime
        {
            get
            {
                return mime;
            }

            set
            {
                mime = value;
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

        private List<string> ModelStateErrores(ModelStateDictionary modelo)
        {
            
            List<string> errores = new List<string>();
            foreach (ModelState m in modelo.Values)
            {
                foreach (ModelError e in m.Errors)
                {
                    errores.Add(e.ErrorMessage);
                }
            }
            return errores;
        }

       
        public HttpResponseMessage ObjectoRespuesta()
        {

            HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("ContentType", Mime);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this)));
            ms.Position = 0;
            StreamContent content = new StreamContent(ms);
            resp.Content = content;
            return resp;
        }

        public Respuesta()
        {
            
        }

       
    }
    
}