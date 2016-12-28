using PortalExcursiones.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Drawing;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Web.Hosting;
using System.Configuration;
using PortalExcursiones.Infraestructura.Enumeraciones;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class FotoOperaciones : IOperacionesFotos
    {

        private Respuesta resp = null;

        public FotoOperaciones(Respuesta _resp)
        {
           
            resp = _resp;
        }


        public HttpResponseMessage Subir(HttpRequestMessage request)
        {
            try
            {
                string filename = String.Empty;
                string fullpath = String.Empty;

                if(request.Content.IsMimeMultipartContent())
                {
                    request.Content.LoadIntoBufferAsync().Wait();
                    MultipartMemoryStreamProvider provider = request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(new MultipartMemoryStreamProvider()).Result;
                    foreach (HttpContent content in provider.Contents)
                    {
                        Stream stream = content.ReadAsStreamAsync().Result;
                        Image image = Image.FromStream(stream);
                        string filePath = HostingEnvironment.MapPath("~/" + ConfigurationManager.AppSettings["directoriofotos"] + "/");
                        var guid = Guid.NewGuid();
                        filename = guid + ".jpg";
                        fullpath = Path.Combine(filePath, filename);
                        image.Save(fullpath);
                    }
                    resp.Codigo = (int)Codigos.OK;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                    resp.Contenido = new FotoInfo()
                    {
                        Nombre = filename,
                        Url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + ConfigurationManager.AppSettings["directoriofotos"] + "/" + filename
                    };
                    return resp.ObjectoRespuesta();
                }
                else
                {
                    resp.Codigo = (int)Codigos.CONTENT_TYPE_NO_CORRECTO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.CONTENT_TYPE_NO_CORRECTO);
                    return resp.ObjectoRespuesta();
                }
            }
            catch (Exception ex)
            {
                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();
            }
        }
    }
}