namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facturaitem_proveedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.facturaitem", "proveedor_id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.facturaitem", "proveedor_id");
            AddForeignKey("dbo.facturaitem", "proveedor_id", "dbo.proveedor", "usuario_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.facturaitem", "proveedor_id", "dbo.proveedor");
            DropIndex("dbo.facturaitem", new[] { "proveedor_id" });
            DropColumn("dbo.facturaitem", "proveedor_id");
        }
    }
}
