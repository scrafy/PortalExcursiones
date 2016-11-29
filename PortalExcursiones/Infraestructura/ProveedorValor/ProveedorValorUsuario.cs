using System;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;
using CapaDatos.Entidades;
using Newtonsoft.Json;
using System.Globalization;


namespace PortalExcursiones.Infraestructura.ProveedorValor
{
    public class ProveedorValorUsuario : IValueProvider
    {
        private HttpActionContext contexto;
      

        public ProveedorValorUsuario(HttpActionContext _contexto)
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
            
            if(key.Equals("usuario"))
            {
                if(contexto.Request.Method.Method.Equals("PUT"))
                {
                    usuario usuario = JsonConvert.DeserializeObject<usuario>(contenido);
                    if(aux.id == null)
                        usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                    usuario.PasswordHash = "-";//seteandolo a cadena vacia evitamos que pete la validacion
                    return new ValueProviderResult(usuario, contenido, CultureInfo.InvariantCulture);

                }
            }
            if(key.Equals("cliente"))
            {
                if (contexto.Request.Method.Method.Equals("PUT"))
                {
                    cliente cliente = JsonConvert.DeserializeObject<cliente>(contenido);
                    if(aux.usuario.id == null)
                        cliente.usuario.Id = null;//sino se manda el id machacamos con null el autogenerado por identity

                    cliente.usuario.PasswordHash = "-";//seteandolo a cadena vacia evitamos que pete la validacion
                    return new ValueProviderResult(cliente, contenido, CultureInfo.InvariantCulture);

                }
            }
            return null;
        }
    }

    public class ProveedorValorUsuarioFactory : ValueProviderFactory
    {
        
        public override IValueProvider GetValueProvider(HttpActionContext contexto)
        {
            return new ProveedorValorUsuario(contexto);
        }
    }
}