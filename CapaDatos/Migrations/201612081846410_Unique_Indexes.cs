namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unique_Indexes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.puntorecogida", "descripcion", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.usuario", "contrasena", c => c.String(nullable: false,unicode: false, storeType: "text"));
            AlterColumn("dbo.puntorecogida", "nombre", c => c.String(nullable: false, maxLength: 255, unicode: false));
            CreateIndex("dbo.configuracion", "nombre", unique: true);
            CreateIndex("dbo.categoriactividad", "nombre", unique: true);
            CreateIndex("dbo.categoriaexcursion", "nombre", unique: true);
            CreateIndex("dbo.destino", "nombre", unique: true);
            CreateIndex("dbo.estadoexcursion", "nombre", unique: true);
            CreateIndex("dbo.idioma", "nombre", unique: true);
            CreateIndex("dbo.proveedor", "cif", unique: true);
            CreateIndex("dbo.localidad", "nombre", unique: true);
            CreateIndex("dbo.provincia", "nombre", unique: true);
            CreateIndex("dbo.pais", "nombre", unique: true);
            CreateIndex("dbo.puntorecogida", "nombre", unique: true);
            CreateIndex("dbo.item", "nombre", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.item", new[] { "nombre" });
            DropIndex("dbo.puntorecogida", new[] { "nombre" });
            DropIndex("dbo.pais", new[] { "nombre" });
            DropIndex("dbo.provincia", new[] { "nombre" });
            DropIndex("dbo.localidad", new[] { "nombre" });
            DropIndex("dbo.proveedor", new[] { "cif" });
            DropIndex("dbo.idioma", new[] { "nombre" });
            DropIndex("dbo.estadoexcursion", new[] { "nombre" });
            DropIndex("dbo.destino", new[] { "nombre" });
            DropIndex("dbo.categoriaexcursion", new[] { "nombre" });
            DropIndex("dbo.categoriactividad", new[] { "nombre" });
            DropIndex("dbo.configuracion", new[] { "nombre" });
            AlterColumn("dbo.puntorecogida", "nombre", c => c.String(nullable: false, maxLength: 45, unicode: false));
            AlterColumn("dbo.usuario", "contrasena", c => c.String(nullable: false, unicode: false, storeType: "text"));
            DropColumn("dbo.puntorecogida", "descripcion");
        }
    }
}
