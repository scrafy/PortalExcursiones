namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetable_calendarioex_puntorecogida : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.calendarioexcursion_puntorecogida", "puntorecogida_id", "dbo.puntorecogida");
            DropForeignKey("dbo.calendarioexcursion_puntorecogida", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion");
            DropIndex("dbo.calendarioexcursion_puntorecogida", new[] { "exact_id", "fecha" });
            DropIndex("dbo.calendarioexcursion_puntorecogida", new[] { "puntorecogida_id" });
            DropTable("dbo.calendarioexcursion_puntorecogida");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.calendarioexcursion_puntorecogida",
                c => new
                    {
                        exact_id = c.Long(nullable: false, storeType: "uint"),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        puntorecogida_id = c.Long(nullable: false, storeType: "uint"),
                        hora = c.Time(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.exact_id, t.fecha, t.puntorecogida_id });
            
            CreateIndex("dbo.calendarioexcursion_puntorecogida", "puntorecogida_id");
            CreateIndex("dbo.calendarioexcursion_puntorecogida", new[] { "exact_id", "fecha" });
            AddForeignKey("dbo.calendarioexcursion_puntorecogida", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion", new[] { "exact_id", "fecha" });
            AddForeignKey("dbo.calendarioexcursion_puntorecogida", "puntorecogida_id", "dbo.puntorecogida", "id");
        }
    }
}
