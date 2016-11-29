using Microsoft.Practices.Unity;
using CapaDatos.Entidades;
using Unity.WebApi;
using System.Web.Http;
using PortalExcursiones.Modelos.ModelosSalida;
using CapaDatos.Identity;
using CapaDatos;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http.Dependencies;
using System.Collections.Generic;
using System.Web;
using Microsoft.Owin.Security.DataProtection;
using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Infraestructura.ImplementacionInterfaces;
using Microsoft.Owin.Security;


namespace PortalExcursiones
{
    public static class ResolvedorDependencias 
    {
        private static UnityContainer contenedor = new UnityContainer();

        public static void Inicializar()
        {
            ConfigurarContenedor();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(contenedor);
           
        }

        private static void ConfigurarContenedor()
        {
            contenedor.RegisterType<Contexto>(new CicloVidaObjecto<Contexto>());
            contenedor.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            contenedor.RegisterType<AdministradorUsuario>(new CicloVidaObjecto<AdministradorUsuario>(),new InjectionMethod("SetDataProtectionProvider", contenedor.Resolve<IDataProtectionProvider>()));
            contenedor.RegisterType<Respuesta>(new CicloVidaObjecto<Respuesta>());
            contenedor.RegisterType<IUserStore<usuario>, UserStore<usuario>>(new CicloVidaObjecto<UserStore<usuario>>(), new InjectionConstructor(contenedor.Resolve<Contexto>()));
            contenedor.RegisterType<IOperacionesComunes<cliente>, ClienteOperacionesComunes>(new CicloVidaObjecto<ClienteOperacionesComunes>());
            contenedor.RegisterType<IOperacionesComunes<usuario>, UsuarioOperacionesComunes>(new CicloVidaObjecto<UsuarioOperacionesComunes>());
            contenedor.RegisterType<IOperacionesUsuario, OperacionesUsuario>(new CicloVidaObjecto<OperacionesUsuario>());
        }

        public static UnityContainer ObtenerContenedor()
        {
            return contenedor;
        }

        
    }

    public class CicloVidaObjecto<T> : LifetimeManager, IDisposable
    {
        public override object GetValue()
        {
            return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
        }
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(typeof(T).AssemblyQualifiedName);
        }
        public override void SetValue(object valor)
        {
            HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = valor;
        }
        public void Dispose()
        {
            RemoveValue();
        }
    }
}