namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_field_genero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.grupoedad", "genero", c => c.String(nullable: false, maxLength: 100, storeType: "nvarchar"));
            DropColumn("dbo.grupoedad", "nombrerango");
        }
        
        public override void Down()
        {
            AddColumn("dbo.grupoedad", "nombrerango", c => c.Int(nullable: false));
            DropColumn("dbo.grupoedad", "genero");
        }
    }
}
