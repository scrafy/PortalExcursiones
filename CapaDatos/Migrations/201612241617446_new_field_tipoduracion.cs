namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_field_tipoduracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.excursionactividad", "tipoduracion", c => c.String(nullable: false, maxLength: 60, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.excursionactividad", "tipoduracion");
        }
    }
}
