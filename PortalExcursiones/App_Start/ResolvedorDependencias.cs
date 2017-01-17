using Microsoft.Practices.Unity;
using CapaDatos.Entidades;
using Unity.WebApi;
using System.Web.Http;
using PortalExcursiones.Modelos.ModelosSalida;
using PortalExcursiones.Modelos.ModelosEntrada;
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
using PortalExcursiones.Infraestructura.LogicaComun;

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
            contenedor.RegisterType<IOperacionesComunes<cliente>, ClienteOperaciones>(new CicloVidaObjecto<ClienteOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<usuario>, UsuarioOperaciones>(new CicloVidaObjecto<UsuarioOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<proveedor>, ProveedorOperaciones>(new CicloVidaObjecto<ProveedorOperaciones>());
            contenedor.RegisterType<IOperacionesCalendarioExcursionActividad, CalendarioExcursionOperaciones>(new CicloVidaObjecto<CalendarioExcursionOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<categoriaexcursion>, CategoriaExcursionOperaciones>(new CicloVidaObjecto<CategoriaExcursionOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<categoriactividad>, CategoriActividadOperacionesComunes>(new CicloVidaObjecto<CategoriActividadOperacionesComunes>());
            contenedor.RegisterType<IOperacionesComunes<excursionactividad>, ExcursionActividadOperaciones>(new CicloVidaObjecto<ExcursionActividadOperaciones>());
            contenedor.RegisterType<IOperacionesExcursionActividad, ExcursionActividadOperaciones>(new CicloVidaObjecto<ExcursionActividadOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<preciotemporada>, PrecioPorTemporadaOperaciones>(new CicloVidaObjecto<PrecioPorTemporadaOperaciones>());
            contenedor.RegisterType<IOperacionesPuntoRecogida, PuntoRecogidaOperaciones>(new CicloVidaObjecto<PuntoRecogidaOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<fotoconfiguracion>, FotoConfiguracionOperaciones>(new CicloVidaObjecto<FotoConfiguracionOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<idioma>, IdiomaOperaciones>(new CicloVidaObjecto<IdiomaOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<item>, ItemOperaciones>(new CicloVidaObjecto<ItemOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<ReservaExcursionActividadModel>, ReservaExcActOperaciones>(new CicloVidaObjecto<ReservaExcActOperaciones>());
            contenedor.RegisterType<IOperacionesPasarelaPago, ReservaExcActOperaciones>(new CicloVidaObjecto<ReservaExcActOperaciones>());
            contenedor.RegisterType<IOperacionesFotos, FotoOperaciones>(new CicloVidaObjecto<FotoOperaciones>());
            contenedor.RegisterType<IOperacionesUsuario, UsuarioOperaciones>(new CicloVidaObjecto<UsuarioOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<grupoedad>, GrupoEdadOperaciones>(new CicloVidaObjecto<GrupoEdadOperaciones>());
            contenedor.RegisterType<ICreacionMultiple<grupoedad>, GrupoEdadOperaciones>(new CicloVidaObjecto<GrupoEdadOperaciones>());
            contenedor.RegisterType<IOperacionesComunes<facturaitem>, FacturaItemOperaciones>(new CicloVidaObjecto<FacturaItemOperaciones>());
            contenedor.RegisterType<IGeneracionInformes, ConsultaOperaciones>(new CicloVidaObjecto<ConsultaOperaciones>()); 
            contenedor.RegisterType<GestionAvisosEmail>(new CicloVidaObjecto<GestionAvisosEmail>());
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