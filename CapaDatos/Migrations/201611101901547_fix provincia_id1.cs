namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixprovincia_id1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.localidad", "provincia_id1", "dbo.provincia");
            DropIndex("dbo.localidad", new[] { "provincia_id1" });
            DropColumn("dbo.localidad", "provincia_id");
            RenameColumn(table: "dbo.localidad", name: "provincia_id1", newName: "provincia_id");
            AlterColumn("dbo.localidad", "provincia_id", c => c.Long(nullable: false, storeType: "int unsigned"));
            CreateIndex("dbo.localidad", "provincia_id");
            AddForeignKey("dbo.localidad", "provincia_id", "dbo.provincia", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.localidad", "provincia_id", "dbo.provincia");
            DropIndex("dbo.localidad", new[] { "provincia_id" });
            AlterColumn("dbo.localidad", "provincia_id", c => c.Long(storeType: "int unsigned"));
            RenameColumn(table: "dbo.localidad", name: "provincia_id", newName: "provincia_id1");
            AddColumn("dbo.localidad", "provincia_id", c => c.Long(nullable: false, storeType: "int unsigned"));
            CreateIndex("dbo.localidad", "provincia_id1");
            AddForeignKey("dbo.localidad", "provincia_id1", "dbo.provincia", "id");
        }
    }
}
