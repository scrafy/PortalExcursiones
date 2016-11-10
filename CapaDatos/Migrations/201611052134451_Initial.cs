namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.alquilervehiculo",
                c => new
                    {
                        alquiler_id = c.Long(nullable: false, storeType: "int unsigned"),
                        observaciones = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.alquiler_id)
                .ForeignKey("dbo.configuracion", t => t.alquiler_id)
                .Index(t => t.alquiler_id);
            
            CreateTable(
                "dbo.configuracion",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        ocultarweb = c.Boolean(nullable: false),
                        video = c.String(maxLength: 100, unicode: false),
                        tadvisor = c.String(maxLength: 100, unicode: false),
                        lat = c.String(nullable: false, maxLength: 50, unicode: false),
                        lng = c.String(nullable: false, maxLength: 50, unicode: false),
                        logo = c.String(nullable: false, maxLength: 100, unicode: false),
                        proveedor_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.proveedor", t => t.proveedor_id)
                .Index(t => t.proveedor_id);
            
            CreateTable(
                "dbo.excursionactividad",
                c => new
                    {
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                        duracion = c.Short(nullable: false),
                        minpersonas = c.Short(nullable: false),
                        maxpersonas = c.Short(nullable: false),
                        descuento = c.Decimal(precision: 18, scale: 2),
                        queharas = c.String(nullable: false, unicode: false, storeType: "text"),
                        queesperar = c.String(nullable: false, unicode: false, storeType: "text"),
                        noincluye = c.String(nullable: false, unicode: false, storeType: "text"),
                        antesdeir = c.String(nullable: false, unicode: false, storeType: "text"),
                        esexcursion = c.Boolean(nullable: false),
                        secontabilizaninfantes = c.Boolean(nullable: false),
                        pickupservice = c.Boolean(nullable: false),
                        destino_id = c.Long(nullable: false, storeType: "int unsigned"),
                        tipoexcursion_id = c.Byte(storeType: "tinyint unsigned"),
                        tipoactividad_id = c.Byte(storeType: "tinyint unsigned"),
                    })
                .PrimaryKey(t => t.exact_id)
                .ForeignKey("dbo.categoriactividad", t => t.tipoactividad_id)
                .ForeignKey("dbo.categoriaexcursion", t => t.tipoexcursion_id)
                .ForeignKey("dbo.destino", t => t.destino_id)
                .ForeignKey("dbo.configuracion", t => t.exact_id)
                .Index(t => t.exact_id)
                .Index(t => t.destino_id)
                .Index(t => t.tipoexcursion_id)
                .Index(t => t.tipoactividad_id);
            
            CreateTable(
                "dbo.categoriactividad",
                c => new
                    {
                        id = c.Byte(nullable: false, identity: true, storeType: "tinyint unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.categoriaexcursion",
                c => new
                    {
                        id = c.Byte(nullable: false, identity: true, storeType: "tinyint unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.destino",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.calendarioexcursion",
                c => new
                    {
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        estadoexcursion_id = c.Byte(nullable: false, storeType: "tinyint unsigned"),
                    })
                .PrimaryKey(t => new { t.exact_id, t.fecha })
                .ForeignKey("dbo.estadoexcursion", t => t.estadoexcursion_id)
                .ForeignKey("dbo.excursionactividad", t => t.exact_id)
                .Index(t => t.exact_id)
                .Index(t => t.estadoexcursion_id);
            
            CreateTable(
                "dbo.estadoexcursion",
                c => new
                    {
                        id = c.Byte(nullable: false, identity: true, storeType: "tinyint unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.calendarioexcursion_guia",
                c => new
                    {
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        guia_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => new { t.exact_id, t.fecha, t.guia_id })
                .ForeignKey("dbo.guia", t => t.guia_id)
                .ForeignKey("dbo.calendarioexcursion", t => new { t.exact_id, t.fecha })
                .Index(t => new { t.exact_id, t.fecha })
                .Index(t => t.guia_id);
            
            CreateTable(
                "dbo.guia",
                c => new
                    {
                        usuario_id = c.Long(nullable: false, storeType: "int unsigned"),
                        nota = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.usuario_id)
                .ForeignKey("dbo.usuario", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.idioma_guia",
                c => new
                    {
                        idioma_id = c.Int(nullable: false, storeType: "smallint unsigned"),
                        guia_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => new { t.idioma_id, t.guia_id })
                .ForeignKey("dbo.idioma", t => t.idioma_id)
                .ForeignKey("dbo.guia", t => t.guia_id)
                .Index(t => t.idioma_id)
                .Index(t => t.guia_id);
            
            CreateTable(
                "dbo.idioma",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true, storeType: "smallint unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.usuario",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                        primerapellido = c.String(nullable: false, maxLength: 45, unicode: false),
                        segundoapellido = c.String(nullable: false, maxLength: 45, unicode: false),
                        email = c.String(nullable: false, maxLength: 60, unicode: false),
                        direccion1 = c.String(nullable: false, maxLength: 255, unicode: false),
                        direccion2 = c.String(maxLength: 255, unicode: false),
                        telefono1 = c.String(nullable: false, maxLength: 30, unicode: false),
                        telefono2 = c.String(maxLength: 30, unicode: false),
                        localidad_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.localidad", t => t.localidad_id)
                .Index(t => t.localidad_id);
            
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        usuario_id = c.Long(nullable: false, storeType: "int unsigned"),
                        numidentificacion = c.String(nullable: false, maxLength: 30, unicode: false),
                        infadicional = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.usuario_id)
                .ForeignKey("dbo.usuario", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.reserva",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        fechatransaccion = c.DateTime(nullable: false, precision: 0),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        factura = c.String(nullable: false, maxLength: 100, unicode: false),
                        cliente_id = c.Long(nullable: false, storeType: "int unsigned"),
                        proveedor_id = c.Long(nullable: false, storeType: "int unsigned"),
                        colaborador_id = c.Long(storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.colaborador", t => t.colaborador_id)
                .ForeignKey("dbo.proveedor", t => t.proveedor_id)
                .ForeignKey("dbo.cliente", t => t.cliente_id)
                .Index(t => t.cliente_id)
                .Index(t => t.proveedor_id)
                .Index(t => t.colaborador_id);
            
            CreateTable(
                "dbo.colaborador",
                c => new
                    {
                        usuario_id = c.Long(nullable: false, storeType: "int unsigned"),
                        nombreempresa = c.String(maxLength: 45, unicode: false),
                        cif = c.String(maxLength: 40, unicode: false),
                        lat = c.String(nullable: false, maxLength: 50, unicode: false),
                        lng = c.String(nullable: false, maxLength: 50, unicode: false),
                        observaciones = c.String(unicode: false, storeType: "text"),
                        cifenfactura = c.Boolean(nullable: false),
                        igicdetallado = c.Boolean(nullable: false),
                        porcentaje = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.usuario_id)
                .ForeignKey("dbo.usuario", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.proveedor",
                c => new
                    {
                        usuario_id = c.Long(nullable: false, storeType: "int unsigned"),
                        nombreempresa = c.String(nullable: false, maxLength: 45, unicode: false),
                        cif = c.String(nullable: false, maxLength: 45, unicode: false),
                        observaciones = c.String(unicode: false, storeType: "text"),
                        lat = c.String(nullable: false, maxLength: 60, unicode: false),
                        lng = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.usuario_id)
                .ForeignKey("dbo.usuario", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.reservaexcursionactividad",
                c => new
                    {
                        reserva_id = c.Long(nullable: false, storeType: "int unsigned"),
                        numadultos = c.Byte(nullable: false),
                        numninos = c.Byte(nullable: false),
                        numinfantes = c.Byte(nullable: false),
                        direccion = c.String(maxLength: 255, unicode: false),
                        nombrehotel = c.String(maxLength: 45, unicode: false),
                        observaciones = c.String(unicode: false, storeType: "text"),
                        localidad_id = c.Long(storeType: "int unsigned"),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.reserva_id)
                .ForeignKey("dbo.localidad", t => t.localidad_id)
                .ForeignKey("dbo.reserva", t => t.reserva_id)
                .ForeignKey("dbo.calendarioexcursion", t => new { t.exact_id, t.fecha })
                .Index(t => t.reserva_id)
                .Index(t => t.localidad_id)
                .Index(t => new { t.exact_id, t.fecha });
            
            CreateTable(
                "dbo.localidad",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                        cp = c.Int(nullable: false),
                        provincia_id = c.Long(nullable: false, storeType: "int unsigned"),
                        
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.provincia", t => t.provincia_id)
                .Index(t => t.provincia_id);
            
            CreateTable(
                "dbo.provincia",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        pais_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.pais", t => t.pais_id)
                .Index(t => t.pais_id);
            
            CreateTable(
                "dbo.pais",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.puntorecogida",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                        lat = c.String(nullable: false, maxLength: 50, unicode: false),
                        lng = c.String(nullable: false, maxLength: 50, unicode: false),
                        direccion = c.String(nullable: false, maxLength: 255, unicode: false),
                        localidad_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.localidad", t => t.localidad_id)
                .Index(t => t.localidad_id);
            
            CreateTable(
                "dbo.calendarioexcursion_puntorecogida",
                c => new
                    {
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        puntorecogida_id = c.Long(nullable: false, storeType: "int unsigned"),
                        hora = c.Time(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.exact_id, t.fecha, t.puntorecogida_id })
                .ForeignKey("dbo.puntorecogida", t => t.puntorecogida_id)
                .ForeignKey("dbo.calendarioexcursion", t => new { t.exact_id, t.fecha })
                .Index(t => new { t.exact_id, t.fecha })
                .Index(t => t.puntorecogida_id);
            
            CreateTable(
                "dbo.recogidadevolucion",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        lat = c.String(nullable: false, maxLength: 50, unicode: false),
                        lng = c.String(nullable: false, maxLength: 50, unicode: false),
                        direccion = c.String(nullable: false, maxLength: 255, unicode: false),
                        telefono = c.String(nullable: false, maxLength: 45, unicode: false),
                        localidad_id = c.Long(nullable: false, storeType: "int unsigned"),
                        alquiler_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.localidad", t => t.localidad_id)
                .ForeignKey("dbo.alquilervehiculo", t => t.alquiler_id)
                .Index(t => t.localidad_id)
                .Index(t => t.alquiler_id);
            
            CreateTable(
                "dbo.reservavehiculo",
                c => new
                    {
                        reserva_id = c.Long(nullable: false, storeType: "int unsigned"),
                        fecha_entrega = c.DateTime(nullable: false, precision: 0),
                        numdias = c.Byte(nullable: false),
                        numhoras = c.Byte(nullable: false),
                        vehiculo_id = c.Long(nullable: false, storeType: "int unsigned"),
                        puntorecogida_id = c.Long(nullable: false, storeType: "int unsigned"),
                        puntodevolucion_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.reserva_id)
                .ForeignKey("dbo.vehiculo", t => t.vehiculo_id)
                .ForeignKey("dbo.recogidadevolucion", t => t.puntorecogida_id)
                .ForeignKey("dbo.recogidadevolucion", t => t.puntodevolucion_id)
                .ForeignKey("dbo.reserva", t => t.reserva_id)
                .Index(t => t.reserva_id)
                .Index(t => t.vehiculo_id)
                .Index(t => t.puntorecogida_id)
                .Index(t => t.puntodevolucion_id);
            
            CreateTable(
                "dbo.vehiculo",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        marca = c.String(nullable: false, maxLength: 100, unicode: false),
                        modelo = c.String(nullable: false, maxLength: 100, unicode: false),
                        matircula = c.String(maxLength: 45, unicode: false),
                        kilometros = c.Decimal(precision: 18, scale: 2),
                        imagen = c.String(nullable: false, maxLength: 100, unicode: false),
                        preciopordia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        precioporhora = c.Decimal(nullable: false, precision: 18, scale: 2),
                        maxpasajeros = c.Byte(nullable: false),
                        alquiler_id = c.Long(nullable: false, storeType: "int unsigned"),
                        permisorequerido = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        tipovehiculo_id = c.Byte(nullable: false, storeType: "tinyint unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tipovehiculo", t => t.tipovehiculo_id)
                .ForeignKey("dbo.alquilervehiculo", t => t.alquiler_id)
                .Index(t => t.alquiler_id)
                .Index(t => t.tipovehiculo_id);
            
            CreateTable(
                "dbo.tipovehiculo",
                c => new
                    {
                        id = c.Byte(nullable: false, storeType: "tinyint unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.excursion_contiene_item",
                c => new
                    {
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                        item_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => new { t.exact_id, t.item_id })
                .ForeignKey("dbo.item", t => t.item_id)
                .ForeignKey("dbo.excursionactividad", t => t.exact_id)
                .Index(t => t.exact_id)
                .Index(t => t.item_id);
            
            CreateTable(
                "dbo.item",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                        url = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.preciotemporada",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        desde = c.DateTime(nullable: false, storeType: "date"),
                        hasta = c.DateTime(nullable: false, storeType: "date"),
                        pvpadulto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pvpnino = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pvpinfante = c.Decimal(nullable: false, precision: 18, scale: 2),
                        costeadulto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        costenino = c.Decimal(nullable: false, precision: 18, scale: 2),
                        costeinfante = c.Decimal(nullable: false, precision: 18, scale: 2),
                        netoadulto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        netonino = c.Decimal(nullable: false, precision: 18, scale: 2),
                        netoinfante = c.Decimal(nullable: false, precision: 18, scale: 2),
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.excursionactividad", t => t.exact_id)
                .Index(t => t.exact_id);
            
            CreateTable(
                "dbo.foto",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        url = c.String(nullable: false, maxLength: 100, unicode: false),
                        nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                        configuracion_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.configuracion", t => t.configuracion_id)
                .Index(t => t.configuracion_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.vehiculo", "alquiler_id", "dbo.alquilervehiculo");
            DropForeignKey("dbo.recogidadevolucion", "alquiler_id", "dbo.alquilervehiculo");
            DropForeignKey("dbo.foto", "configuracion_id", "dbo.configuracion");
            DropForeignKey("dbo.excursionactividad", "exact_id", "dbo.configuracion");
            DropForeignKey("dbo.preciotemporada", "exact_id", "dbo.excursionactividad");
            DropForeignKey("dbo.excursion_contiene_item", "exact_id", "dbo.excursionactividad");
            DropForeignKey("dbo.excursion_contiene_item", "item_id", "dbo.item");
            DropForeignKey("dbo.calendarioexcursion", "exact_id", "dbo.excursionactividad");
            DropForeignKey("dbo.reservaexcursionactividad", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion");
            DropForeignKey("dbo.calendarioexcursion_puntorecogida", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion");
            DropForeignKey("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion");
            DropForeignKey("dbo.proveedor", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.guia", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.colaborador", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.cliente", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.reserva", "cliente_id", "dbo.cliente");
            DropForeignKey("dbo.reservavehiculo", "reserva_id", "dbo.reserva");
            DropForeignKey("dbo.reservaexcursionactividad", "reserva_id", "dbo.reserva");
            DropForeignKey("dbo.usuario", "localidad_id", "dbo.localidad");
            DropForeignKey("dbo.reservaexcursionactividad", "localidad_id", "dbo.localidad");
            DropForeignKey("dbo.recogidadevolucion", "localidad_id", "dbo.localidad");
            DropForeignKey("dbo.reservavehiculo", "puntodevolucion_id", "dbo.recogidadevolucion");
            DropForeignKey("dbo.reservavehiculo", "puntorecogida_id", "dbo.recogidadevolucion");
            DropForeignKey("dbo.vehiculo", "tipovehiculo_id", "dbo.tipovehiculo");
            DropForeignKey("dbo.reservavehiculo", "vehiculo_id", "dbo.vehiculo");
            DropForeignKey("dbo.puntorecogida", "localidad_id", "dbo.localidad");
            DropForeignKey("dbo.calendarioexcursion_puntorecogida", "puntorecogida_id", "dbo.puntorecogida");
            DropForeignKey("dbo.provincia", "pais_id", "dbo.pais");
            DropForeignKey("dbo.localidad", "provincia_id1", "dbo.provincia");
            DropForeignKey("dbo.reserva", "proveedor_id", "dbo.proveedor");
            DropForeignKey("dbo.configuracion", "proveedor_id", "dbo.proveedor");
            DropForeignKey("dbo.reserva", "colaborador_id", "dbo.colaborador");
            DropForeignKey("dbo.idioma_guia", "guia_id", "dbo.guia");
            DropForeignKey("dbo.idioma_guia", "idioma_id", "dbo.idioma");
            DropForeignKey("dbo.calendarioexcursion_guia", "guia_id", "dbo.guia");
            DropForeignKey("dbo.calendarioexcursion", "estadoexcursion_id", "dbo.estadoexcursion");
            DropForeignKey("dbo.excursionactividad", "destino_id", "dbo.destino");
            DropForeignKey("dbo.excursionactividad", "tipoexcursion_id", "dbo.categoriaexcursion");
            DropForeignKey("dbo.excursionactividad", "tipoactividad_id", "dbo.categoriactividad");
            DropForeignKey("dbo.alquilervehiculo", "alquiler_id", "dbo.configuracion");
            DropIndex("dbo.foto", new[] { "configuracion_id" });
            DropIndex("dbo.preciotemporada", new[] { "exact_id" });
            DropIndex("dbo.excursion_contiene_item", new[] { "item_id" });
            DropIndex("dbo.excursion_contiene_item", new[] { "exact_id" });
            DropIndex("dbo.vehiculo", new[] { "tipovehiculo_id" });
            DropIndex("dbo.vehiculo", new[] { "alquiler_id" });
            DropIndex("dbo.reservavehiculo", new[] { "puntodevolucion_id" });
            DropIndex("dbo.reservavehiculo", new[] { "puntorecogida_id" });
            DropIndex("dbo.reservavehiculo", new[] { "vehiculo_id" });
            DropIndex("dbo.reservavehiculo", new[] { "reserva_id" });
            DropIndex("dbo.recogidadevolucion", new[] { "alquiler_id" });
            DropIndex("dbo.recogidadevolucion", new[] { "localidad_id" });
            DropIndex("dbo.calendarioexcursion_puntorecogida", new[] { "puntorecogida_id" });
            DropIndex("dbo.calendarioexcursion_puntorecogida", new[] { "exact_id", "fecha" });
            DropIndex("dbo.puntorecogida", new[] { "localidad_id" });
            DropIndex("dbo.provincia", new[] { "pais_id" });
            DropIndex("dbo.localidad", new[] { "provincia_id1" });
            DropIndex("dbo.reservaexcursionactividad", new[] { "exact_id", "fecha" });
            DropIndex("dbo.reservaexcursionactividad", new[] { "localidad_id" });
            DropIndex("dbo.reservaexcursionactividad", new[] { "reserva_id" });
            DropIndex("dbo.proveedor", new[] { "usuario_id" });
            DropIndex("dbo.colaborador", new[] { "usuario_id" });
            DropIndex("dbo.reserva", new[] { "colaborador_id" });
            DropIndex("dbo.reserva", new[] { "proveedor_id" });
            DropIndex("dbo.reserva", new[] { "cliente_id" });
            DropIndex("dbo.cliente", new[] { "usuario_id" });
            DropIndex("dbo.usuario", new[] { "localidad_id" });
            DropIndex("dbo.idioma_guia", new[] { "guia_id" });
            DropIndex("dbo.idioma_guia", new[] { "idioma_id" });
            DropIndex("dbo.guia", new[] { "usuario_id" });
            DropIndex("dbo.calendarioexcursion_guia", new[] { "guia_id" });
            DropIndex("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha" });
            DropIndex("dbo.calendarioexcursion", new[] { "estadoexcursion_id" });
            DropIndex("dbo.calendarioexcursion", new[] { "exact_id" });
            DropIndex("dbo.excursionactividad", new[] { "tipoactividad_id" });
            DropIndex("dbo.excursionactividad", new[] { "tipoexcursion_id" });
            DropIndex("dbo.excursionactividad", new[] { "destino_id" });
            DropIndex("dbo.excursionactividad", new[] { "exact_id" });
            DropIndex("dbo.configuracion", new[] { "proveedor_id" });
            DropIndex("dbo.alquilervehiculo", new[] { "alquiler_id" });
            DropTable("dbo.foto");
            DropTable("dbo.preciotemporada");
            DropTable("dbo.item");
            DropTable("dbo.excursion_contiene_item");
            DropTable("dbo.tipovehiculo");
            DropTable("dbo.vehiculo");
            DropTable("dbo.reservavehiculo");
            DropTable("dbo.recogidadevolucion");
            DropTable("dbo.calendarioexcursion_puntorecogida");
            DropTable("dbo.puntorecogida");
            DropTable("dbo.pais");
            DropTable("dbo.provincia");
            DropTable("dbo.localidad");
            DropTable("dbo.reservaexcursionactividad");
            DropTable("dbo.proveedor");
            DropTable("dbo.colaborador");
            DropTable("dbo.reserva");
            DropTable("dbo.cliente");
            DropTable("dbo.usuario");
            DropTable("dbo.idioma");
            DropTable("dbo.idioma_guia");
            DropTable("dbo.guia");
            DropTable("dbo.calendarioexcursion_guia");
            DropTable("dbo.estadoexcursion");
            DropTable("dbo.calendarioexcursion");
            DropTable("dbo.destino");
            DropTable("dbo.categoriaexcursion");
            DropTable("dbo.categoriactividad");
            DropTable("dbo.excursionactividad");
            DropTable("dbo.configuracion");
            DropTable("dbo.alquilervehiculo");
        }
    }
}
