namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_field_id_calendario_excursion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.reservaexcursionactividad", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion");
            DropIndex("dbo.reservaexcursionactividad", new[] { "exact_id", "fecha" });
            RenameColumn(table: "dbo.reservaexcursionactividad", name: "exact_id", newName: "calendario_id");
            DropPrimaryKey("dbo.calendarioexcursion");
            AddColumn("dbo.calendarioexcursion", "id", c => c.Long(nullable: false, identity: true, storeType: "int auto_increment"));
            AddPrimaryKey("dbo.calendarioexcursion", "id");
            CreateIndex("dbo.reservaexcursionactividad", "calendario_id");
            AddForeignKey("dbo.reservaexcursionactividad", "calendario_id", "dbo.calendarioexcursion", "id");
            DropColumn("dbo.reservaexcursionactividad", "fecha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.reservaexcursionactividad", "fecha", c => c.DateTime(nullable: false, precision: 0));
            DropForeignKey("dbo.reservaexcursionactividad", "calendario_id", "dbo.calendarioexcursion");
            DropIndex("dbo.reservaexcursionactividad", new[] { "calendario_id" });
            DropPrimaryKey("dbo.calendarioexcursion");
            DropColumn("dbo.calendarioexcursion", "id");
            AddPrimaryKey("dbo.calendarioexcursion", new[] { "exact_id", "fecha" });
            RenameColumn(table: "dbo.reservaexcursionactividad", name: "calendario_id", newName: "exact_id");
            CreateIndex("dbo.reservaexcursionactividad", new[] { "exact_id", "fecha" });
            AddForeignKey("dbo.reservaexcursionactividad", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion", new[] { "exact_id", "fecha" });
        }
    }
}


