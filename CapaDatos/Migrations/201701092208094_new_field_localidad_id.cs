namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_field_localidad_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.configuracion", "localidad_id", c => c.Long(nullable: false, storeType: "int unsigned"));
            CreateIndex("dbo.configuracion", "localidad_id");
            AddForeignKey("dbo.configuracion", "localidad_id", "dbo.localidad", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.configuracion", "localidad_id", "dbo.localidad");
            DropIndex("dbo.configuracion", new[] { "localidad_id" });
            DropColumn("dbo.configuracion", "localidad_id");
        }
    }
}
