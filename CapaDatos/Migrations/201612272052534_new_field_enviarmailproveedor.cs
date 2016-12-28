namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_field_enviarmailproveedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.proveedor", "emailfactura", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.proveedor", "emailfactura");
        }
    }
}
