namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table_grupoedad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.grupoedad",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                        nombrerango = c.Byte(nullable: false),
                        edaddesde = c.Byte(nullable: false),
                        edadhasta = c.Byte(nullable: false),
                        exact_id = c.Long(nullable: false, storeType: "int unsigned"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.excursionactividad", t => t.exact_id)
                .Index(t => t.exact_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.grupoedad", "exact_id", "dbo.excursionactividad");
            DropIndex("dbo.grupoedad", new[] { "exact_id" });
            DropTable("dbo.grupoedad");
        }
    }
}
