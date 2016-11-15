using System.Web.Http;
using CapaDatos;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using PortalExcursiones.Modelos.ModelosSalida;
using System;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Controladores
{
    public abstract class BaseController : ApiController
    {
        protected Contexto context = new Contexto();
               
        protected HttpResponseMessage ObjectoRespuesta(Codigos codigo,object o=null,Exception ex=null,string mensaje_error=null, ModelStateDictionary model =null,string mime="application/json")
        {

            Respuesta res = new Respuesta()
            {
                Codigo = (int)codigo,
                Mensaje = Enum.GetName(typeof(Codigos), (int)codigo),
                Mensaje_error = mensaje_error,
                Excepcion = Excepcion.Create(ex),
                Erroresvalidacion = Respuesta.ObtenerErroresValidacion(model),
                Contenido = o
            };
            HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("ContentType", mime);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)));
            ms.Position = 0;
            StreamContent content = new StreamContent(ms);
            resp.Content = content;
            return resp;
        }
       
    }
}
