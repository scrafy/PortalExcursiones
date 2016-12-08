using System;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;
using CapaDatos.Entidades;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;
using PortalExcursiones.Modelos.ModelosEntrada;

namespace PortalExcursiones.Infraestructura.ProveedorValor
{
    public class ProveedorValor : IValueProvider
    {
        private HttpActionContext contexto;
      

        public ProveedorValor(HttpActionContext _contexto)
        {
            contexto = _contexto;
        }

        
        public bool ContainsPrefix(string prefix)
        {
            return false;
        }

        public ValueProviderResult GetValue(string key)
        {
            string contenido = contexto.Request.Content.ReadAsStringAsync().Result;
            dynamic aux = JsonConvert.DeserializeObject<dynamic>(contenido);

            if(contexto.Request.Method.Method.Equals("PUT"))
            {
                switch (key)
                {
                    case "usuario":
                        usuario usuario = JsonConvert.DeserializeObject<usuario>(contenido);
                        if (aux.id == null)
                            usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                        return new ValueProviderResult(usuario, contenido, CultureInfo.InvariantCulture);
                     
                    case "cliente":
                        cliente cliente = JsonConvert.DeserializeObject<cliente>(contenido);
                        if (aux.usuario.id == null)
                            cliente.usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                        return new ValueProviderResult(cliente, contenido, CultureInfo.InvariantCulture);
                    case "guia":
                        guia guia = JsonConvert.DeserializeObject<guia>(contenido);
                        if (aux.usuario.id == null)
                            guia.usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                        return new ValueProviderResult(guia, contenido, CultureInfo.InvariantCulture);
                    case "proveedor":
                        proveedor proveedor = JsonConvert.DeserializeObject<proveedor>(contenido);
                        if (aux.usuario.id == null)
                            proveedor.usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                        return new ValueProviderResult(proveedor, contenido, CultureInfo.InvariantCulture);
                    case "colaborador":
                        colaborador colaborador = JsonConvert.DeserializeObject<colaborador>(contenido);
                        if (aux.usuario.id == null)
                            colaborador.usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                        return new ValueProviderResult(colaborador, contenido, CultureInfo.InvariantCulture);

                }

                
            }
            if (contexto.Request.Method.Method.Equals("POST"))
            {
                switch(key)
                {
                    case "calendarioexcursion":
                        CalendarioExcursionModel calendario = JsonConvert.DeserializeObject<CalendarioExcursionModel>(contenido);
                        DateTime dt = new DateTime();
                        DateTime.TryParse(aux.desde==null ? "01/01/0001 00:00:00": aux.desde.ToString(), Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out dt);
                        calendario.Desde = dt;
                        DateTime.TryParse(aux.hasta == null ? "01/01/0001 00:00:00" : aux.hasta.ToString(), Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out dt);
                        calendario.Hasta = dt;
                        return new ValueProviderResult(calendario, contenido, CultureInfo.InvariantCulture);
                  
                }
            }
            return null;
        }
    }

    public class ProveedorValorFactory : ValueProviderFactory
    {
        
        public override IValueProvider GetValueProvider(HttpActionContext contexto)
        {
            return new ProveedorValor(contexto);
        }
    }
}