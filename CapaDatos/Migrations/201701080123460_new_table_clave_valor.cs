namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table_clave_valor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.clavevalor",
                c => new
                    {
                        clave = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        valor = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.clave);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.clavevalor");
        }
    }
}
