namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exact_join_puntorecogida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.puntorecogida", "exact_id", c => c.Long(nullable: false, storeType: "int unsigned"));
            CreateIndex("dbo.puntorecogida", "exact_id");
            AddForeignKey("dbo.puntorecogida", "exact_id", "dbo.excursionactividad", "exact_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.puntorecogida", "exact_id", "dbo.excursionactividad");
            DropIndex("dbo.puntorecogida", new[] { "exact_id" });
            DropColumn("dbo.puntorecogida", "exact_id");
        }
    }
}
