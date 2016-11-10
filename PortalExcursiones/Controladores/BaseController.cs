using System.Web.Http;
using CapaDatos;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text;



namespace PortalExcursiones.Controladores
{
    public class BaseController : ApiController
    {
        protected Contexto context = new Contexto();
        

        protected HttpResponseMessage ObjectoRespuesta(HttpStatusCode statuscode,object o,string mime="application/json")
        {
            HttpResponseMessage resp = new HttpResponseMessage(statuscode);
            resp.Headers.Add("ContentType", mime);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o)));
            ms.Position = 0;
            StreamContent content = new StreamContent(ms);
            resp.Content = content;
            return resp;
        }
       
    }
}
