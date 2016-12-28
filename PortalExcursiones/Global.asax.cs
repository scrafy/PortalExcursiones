using System.Configuration;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Web.Http;
//using System.Web.Mvc;
using System.Web.Routing;

namespace PortalExcursiones
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
           GlobalConfiguration.Configure(WebApiConfig.Register);
           // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           RouteConfig.RegisterRoutes(RouteTable.Routes);
        
        }

        protected void Application_BeginRequest()
        {
            if(this.Request.Cookies.Get("idioma") != null)
            {
                string idioma = this.Request.Cookies.Get("idioma").Value;
                CultureInfo c = new CultureInfo(idioma);
                Thread.CurrentThread.CurrentCulture = c;
                Thread.CurrentThread.CurrentUICulture = c;
            }
            else
            {
                CultureInfo c = new CultureInfo(ConfigurationManager.AppSettings["idiomadefecto"]);
                Thread.CurrentThread.CurrentCulture = c;
                Thread.CurrentThread.CurrentUICulture = c;
            }
           /* byte[] buffer = new byte[this.Request.InputStream.Length];
            this.Request.InputStream.Read(buffer, 0, buffer.Length);
            string input = Encoding.UTF8.GetString(buffer);*/
            DateTimeFormatInfo formato = new DateTimeFormatInfo();
            formato.DateSeparator = "-";
            formato.TimeSeparator = ":";
            formato.ShortDatePattern = "dd-MM-yyyy";
            formato.ShortTimePattern = "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture.DateTimeFormat = formato;
            Thread.CurrentThread.CurrentUICulture.DateTimeFormat = formato;
            ResolvedorDependencias.Inicializar();
           
        }
    }
}
