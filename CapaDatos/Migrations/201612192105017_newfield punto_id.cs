namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldpunto_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.reservaexcursionactividad", "punto_id", c => c.Long(storeType: "int unsigned"));
            CreateIndex("dbo.reservaexcursionactividad", "punto_id");
            AddForeignKey("dbo.reservaexcursionactividad", "punto_id", "dbo.puntorecogida", "id", false);
        }
        
        public override void Down()
        {
            DropIndex("dbo.reservaexcursionactividad", new[] { "punto_id" });
            DropColumn("dbo.reservaexcursionactividad", "punto_id");
        }
    }
}
