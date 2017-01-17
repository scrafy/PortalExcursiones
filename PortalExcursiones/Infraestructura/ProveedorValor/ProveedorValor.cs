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
                                  
                    case "proveedor":
                        proveedor proveedor = JsonConvert.DeserializeObject<proveedor>(contenido);
                        if (aux.usuario.id == null)
                            proveedor.usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                        return new ValueProviderResult(proveedor, contenido, CultureInfo.InvariantCulture);

                   

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