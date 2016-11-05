namespace CapaDatos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entidades;
    using ConfiguracionEntidades;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
            this.Configuration.LazyLoadingEnabled = false;
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
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<vehiculo> vehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConfiguracionAlquilerVehiculo());
            modelBuilder.Configurations.Add(new ConfiguracionCalendarioExcursion());
            modelBuilder.Configurations.Add(new ConfiguracionCategoriaActividad());
            modelBuilder.Configurations.Add(new ConfiguracionCategoriaExcursion());
            modelBuilder.Configurations.Add(new ConfiguracionCliente());
            modelBuilder.Configurations.Add(new ConfiguracionColaborador());
            modelBuilder.Configurations.Add(new ConfiguracionConfiguracion());
            modelBuilder.Configurations.Add(new ConfiguracionDestino());
            modelBuilder.Configurations.Add(new ConfiguracionEstadoExcursion());
            modelBuilder.Configurations.Add(new ConfiguracionExcursionActividad());
            modelBuilder.Configurations.Add(new ConfiguracionFoto());
            modelBuilder.Configurations.Add(new ConfiguracionGuia());
            modelBuilder.Configurations.Add(new ConfiguracionIdioma());
            modelBuilder.Configurations.Add(new ConfiguracionItem());
            modelBuilder.Configurations.Add(new ConfiguracionLocalidad());
            modelBuilder.Configurations.Add(new ConfiguracionPais());
            modelBuilder.Configurations.Add(new ConfiguracionProveedor());
            modelBuilder.Configurations.Add(new ConfiguracionPuntoRecogida());
            modelBuilder.Configurations.Add(new ConfiguracionRecogidaDevolucion());
            modelBuilder.Configurations.Add(new ConfiguracionReserva());
            modelBuilder.Configurations.Add(new ConfiguracionReservaExcursionActividad());
            modelBuilder.Configurations.Add(new ConfiguracionTipoVehiculo());
            modelBuilder.Configurations.Add(new ConfiguracionUsuario());
            modelBuilder.Configurations.Add(new ConfiguracionVehiculo());


        }
    }
}
