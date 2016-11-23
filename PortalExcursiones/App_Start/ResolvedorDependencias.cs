using Microsoft.Practices.Unity;
using PortalExcursiones.Controladores.Interfaces;
using CapaDatos.Entidades;
using PortalExcursiones.Controladores.ImplementacionInterfaces;
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
            contenedor.RegisterType<AdministradorUsuario>(new CicloVidaObjecto<AdministradorUsuario>(),new InjectionMethod("SetDataProtectionProvider", contenedor.Resolve<IDataProtectionProvider>()));
            contenedor.RegisterType<Respuesta>(new CicloVidaObjecto<Respuesta>());
            contenedor.RegisterType<IUserStore<usuario>, UserStore<usuario>>(new CicloVidaObjecto<UserStore<usuario>>(), new InjectionConstructor(contenedor.Resolve<Contexto>()));
            contenedor.RegisterType<IOperacionesComunes<cliente>, ClienteServicios>(new CicloVidaObjecto<ClienteServicios>(), new InjectionConstructor(contenedor.Resolve<AdministradorUsuario>(), contenedor.Resolve<Contexto>(), contenedor.Resolve<Respuesta>()));
            contenedor.RegisterType<IOperacionesComunes<usuario>, UsuarioServicios>(new CicloVidaObjecto<UsuarioServicios>());
           
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