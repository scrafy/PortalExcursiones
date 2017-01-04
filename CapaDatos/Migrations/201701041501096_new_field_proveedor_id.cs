namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_field_proveedor_id : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.puntorecogida", new[] { "nombre" });
            AddColumn("dbo.puntorecogida", "proveedor_id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.puntorecogida", "proveedor_id");
            AddForeignKey("dbo.puntorecogida", "proveedor_id", "dbo.proveedor", "usuario_id");
            DropColumn("dbo.puntorecogida_exact", "nota");
        }
        
        public override void Down()
        {
            AddColumn("dbo.puntorecogida_exact", "nota", c => c.String(unicode: false, storeType: "text"));
            DropForeignKey("dbo.puntorecogida", "proveedor_id", "dbo.proveedor");
            DropIndex("dbo.puntorecogida", new[] { "proveedor_id" });
            DropColumn("dbo.puntorecogida", "proveedor_id");
            CreateIndex("dbo.puntorecogida", "nombre", unique: true);
        }
    }
}
