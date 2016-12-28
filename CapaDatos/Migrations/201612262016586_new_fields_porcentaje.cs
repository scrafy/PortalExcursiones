namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_fields_porcentaje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.configuracion", "porcentaje", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.configuracion", "porcentaje");
        }
    }
}
