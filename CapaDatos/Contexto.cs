using System.Data.Entity;
using CapaDatos.Entidades;
using CapaDatos.ConfiguracionEntidades;
using System.Data.Entity.Infrastructure.Interception;
using Microsoft.AspNet.Identity.EntityFramework;


namespace CapaDatos
{

    public partial class Contexto : IdentityDbContext<usuario>
    {
        public Contexto()
            : base("name=Contexto")
        {
           this.Configuration.LazyLoadingEnabled = false;
           DbInterception.Add(new Interceptor());//sirve para registrar las querys a un log
           Database.SetInitializer<Contexto>(null);//evitar que se ejecuten queries extras para comprobar si el modelo conceptual coincide con la base de datos. Al no usar migraciones nos lo podemos ahorrar.
        }

        public virtual DbSet<alquilervehiculo> alquilervehiculo { get; set; }
        public virtual DbSet<calendarioexcursion> calendarioexcursion { get; set; }
        public virtual DbSet<calendarioexcursion_guia> calendarioexcursion_guia { get; set; }
        public virtual DbSet<calendarioexcursion_puntorecogida> calendarioexcursion_puntorecogida { get; set; }
        public virtual DbSet<categoriactividad> categoriactividad { get; set; }
        public virtual DbSet<categoriaexcursion> categoriaexcursion { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<colaborador> colaborador { get; set; }
        public virtual DbSet<configuracion> configuracion { get; set; }
        public virtual DbSet<destino> destino { get; set; }
        public virtual DbSet<estadoexcursion> estadoexcursion { get; set; }
        public virtual DbSet<excursion_contiene_item> excursion_contiene_item { get; set; }
        public virtual DbSet<excursionactividad> excursionactividad { get; set; }
        public virtual DbSet<foto> foto { get; set; }
        public virtual DbSet<guia> guia { get; set; }
        public virtual DbSet<idioma_guia> idioma_guia { get; set; }
        public virtual DbSet<idioma> idiomas { get; set; }
        public virtual DbSet<item> item { get; set; }
        public virtual DbSet<localidad> localidad { get; set; }
        public virtual DbSet<pais> pais { get; set; }
        public virtual DbSet<preciotemporada> preciotemporada { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<provincia> provincia { get; set; }
        public virtual DbSet<puntorecogida> puntorecogida { get; set; }
        public virtual DbSet<recogidadevolucion> recogidadevolucion { get; set; }
        public virtual DbSet<reserva> reserva { get; set; }
        public virtual DbSet<reservaexcursionactividad> reservaexcursionactividad { get; set; }
        public virtual DbSet<reservavehiculo> reservavehiculo { get; set; }
        public virtual DbSet<tipovehiculo> tipovehiculo { get; set; }
        public virtual DbSet<vehiculo> vehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelo)
        {
           
            base.OnModelCreating(modelo);

            modelo.Configurations.Add(new ConfiguracionAlquilerVehiculo());
            modelo.Configurations.Add(new ConfiguracionCalendarioExcursion());
            modelo.Configurations.Add(new ConfiguracionCategoriaActividad());
            modelo.Configurations.Add(new ConfiguracionCategoriaExcursion());
            modelo.Configurations.Add(new ConfiguracionCliente());
            modelo.Configurations.Add(new ConfiguracionColaborador());
            modelo.Configurations.Add(new ConfiguracionConfiguracion());
            modelo.Configurations.Add(new ConfiguracionDestino());
            modelo.Configurations.Add(new ConfiguracionEstadoExcursion());
            modelo.Configurations.Add(new ConfiguracionExcursionActividad());
            modelo.Configurations.Add(new ConfiguracionFoto());
            modelo.Configurations.Add(new ConfiguracionGuia());
            modelo.Configurations.Add(new ConfiguracionIdioma());
            modelo.Configurations.Add(new ConfiguracionItem());
            modelo.Configurations.Add(new ConfiguracionLocalidad());
            modelo.Configurations.Add(new ConfiguracionPais());
            modelo.Configurations.Add(new ConfiguracionProveedor());
            modelo.Configurations.Add(new ConfiguracionPuntoRecogida());
            modelo.Configurations.Add(new ConfiguracionRecogidaDevolucion());
            modelo.Configurations.Add(new ConfiguracionReserva());
            modelo.Configurations.Add(new ConfiguracionReservaExcursionActividad());
            modelo.Configurations.Add(new ConfiguracionTipoVehiculo());
            modelo.Configurations.Add(new ConfiguracionUsuario());
            modelo.Configurations.Add(new ConfiguracionVehiculo());
            modelo.Configurations.Add(new ConfiguracionClaim());
            modelo.Configurations.Add(new ConfiguracionRol());
            modelo.Configurations.Add(new ConfiguracionLogin());
            modelo.Configurations.Add(new ConfiguracionUsuarioRol());

        }
        
        public static Contexto Crear()
        {
            return new Contexto();
        }
    }
}
