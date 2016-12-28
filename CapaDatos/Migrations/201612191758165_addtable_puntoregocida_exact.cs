namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_puntoregocida_exact : DbMigration
    {
        public override void Up()
        {
           CreateTable(
                "dbo.puntorecogida_exact",
                c => new
                    {
                        punto_id = c.Long(nullable: false, storeType: "int unsigned"),
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                        nota = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => new { t.punto_id, t.exact_id })
                .ForeignKey("dbo.puntorecogida", t => t.punto_id)
                .ForeignKey("dbo.excursionactividad", t => t.exact_id)
                .Index(t => t.punto_id)
                .Index(t => t.exact_id);
            
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.puntorecogida_exact", "punto_id", "dbo.puntorecogida");
            DropForeignKey("dbo.puntorecogida_exact", "exact_id", "dbo.excursionactividad");
            DropIndex("dbo.puntorecogida_exact", new[] { "exact_id" });
            DropIndex("dbo.puntorecogida_exact", new[] { "punto_id" });
            DropTable("dbo.puntorecogida_exact");
           
        }
    }
}
