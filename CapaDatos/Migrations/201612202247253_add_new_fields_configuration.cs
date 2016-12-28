namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_fields_configuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.configuracion", "direccion", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.configuracion", "direccion");
        }
    }
}
