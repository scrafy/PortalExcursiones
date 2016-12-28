namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table_facturaitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.facturaitem_exact",
               c => new
               {
                   item_id = c.Long(nullable: false, storeType: "int unsigned"),
                   exact_id = c.Long(nullable: false, storeType: "int unsigned"),
               })
               .PrimaryKey(t => new { t.item_id, t.exact_id })
               .ForeignKey("dbo.facturaitem", t => t.item_id)
               .ForeignKey("dbo.excursionactividad", t => t.exact_id)
               .Index(t => t.item_id)
               .Index(t => t.exact_id);

            CreateTable(
                "dbo.facturaitem",
                c => new
                {
                    id = c.Long(nullable: false, identity: true, storeType: "int unsigned auto_increment"),
                    nombre = c.String(nullable: false, maxLength: 45, unicode: false),
                    descripcion = c.String(nullable: false, unicode: false, storeType: "text"),
                })
                .PrimaryKey(t => t.id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.facturaitem_exact", "exact_id", "dbo.excursionactividad");
            DropForeignKey("dbo.facturaitem_exact", "item_id", "dbo.facturaitem");
            DropIndex("dbo.facturaitem_exact", new[] { "exact_id" });
            DropIndex("dbo.facturaitem_exact", new[] { "item_id" });
            DropTable("dbo.facturaitem");
            DropTable("dbo.facturaitem_exact");
        }
    }
}
