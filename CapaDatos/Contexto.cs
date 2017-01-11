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
        public virtual DbSet<categoriactividad> categoriactividad { get; set; }
        public virtual DbSet<categoriaexcursion> categoriaexcursion { get; set; }
        public virtual DbSet<clavevalor> clavevalor { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<colaborador> colaborador { get; set; }
        public virtual DbSet<configuracion> configuracion { get; set; }
        public virtual DbSet<destino> destino { get; set; }
        public virtual DbSet<estadoexcursion> estadoexcursion { get; set; }
        public virtual DbSet<excursion_contiene_item> excursion_contiene_item { get; set; }
        public virtual DbSet<excursionactividad> excursionactividad { get; set; }
        public virtual DbSet<fotoconfiguracion> fotoconfiguracion { get; set; }
        public virtual DbSet<facturaitem> facturaitem { get; set; }
        public virtual DbSet<facturaitem_exact> facturaitem_exact { get; set; }
        public virtual DbSet<grupoedad> grupoedad { get; set; }
        public virtual DbSet<idioma_exact> idioma_exact { get; set; }
        public virtual DbSet<idioma> idioma { get; set; }
        public virtual DbSet<item> item { get; set; }
        public virtual DbSet<localidad> localidad { get; set; }
        public virtual DbSet<pais> pais { get; set; }
        public virtual DbSet<preciotemporada> preciotemporada { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<provincia> provincia { get; set; }
        public virtual DbSet<puntorecogida> puntorecogida { get; set; }
        public virtual DbSet<puntorecogida_exact> punto_exact { get; set; }
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
            modelo.Configurations.Add(new ConfiguracionFotoConfiguracion());
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
            modelo.Configurations.Add(new ConfiguracionFacturaItem());
            ConfiguracionIdentity(modelo);
   
        }
        
        private void ConfiguracionIdentity(DbModelBuilder modelo)
        {
            modelo.Entity<IdentityUserClaim>().ToTable("claim");
            modelo.Entity<IdentityUserClaim>().HasKey(e => e.Id);
            modelo.Entity<IdentityUserClaim>().Property(e => e.Id).HasColumnName("id");
            modelo.Entity<IdentityUserClaim>().Property(e => e.UserId).HasColumnName("usuario_id").IsRequired();
            modelo.Entity<IdentityUserClaim>().Property(e => e.ClaimType).HasColumnName("tipo").IsOptional().HasColumnType("text").HasColumnType("varchar").HasMaxLength(255);
            modelo.Entity<IdentityUserClaim>().Property(e => e.ClaimValue).HasColumnName("valor").IsOptional().HasColumnType("text").HasColumnType("varchar").HasMaxLength(255);

            modelo.Entity<IdentityRole>().ToTable("rol");
            modelo.Entity<IdentityRole>().HasKey(e => e.Id);
            modelo.Entity<IdentityRole>().Property(e => e.Id).HasColumnName("id");
            modelo.Entity<IdentityRole>().Property(e => e.Name).HasColumnName("nombre").IsRequired().HasMaxLength(60);
            modelo.Entity<IdentityRole>().HasMany(e => e.Users).WithRequired().HasForeignKey(e => e.RoleId).WillCascadeOnDelete(false);

            modelo.Entity<IdentityUserRole>().ToTable("usuario_rol");
            modelo.Entity<IdentityUserRole>().HasKey(e => new { e.UserId, e.RoleId });
            modelo.Entity<IdentityUserRole>().Property(e => e.RoleId).HasColumnName("role_id");
            modelo.Entity<IdentityUserRole>().Property(e => e.UserId).HasColumnName("usuario_id");

            modelo.Entity<IdentityUserLogin>().ToTable("login");
            modelo.Entity<IdentityUserLogin>().ToTable("login").HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });
            modelo.Entity<IdentityUserLogin>().ToTable("login").Property(e => e.LoginProvider).HasColumnName("proveedor");
            modelo.Entity<IdentityUserLogin>().ToTable("login").Property(e => e.ProviderKey).HasColumnName("key");
            modelo.Entity<IdentityUserLogin>().ToTable("login").Property(e => e.UserId).HasColumnName("usuario_id");
        }

        public static Contexto Crear()
        {
            return new Contexto();
        }
    }
}
