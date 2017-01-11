namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfield_motivoanulacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.calendarioexcursion", "motivoanulacion", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.calendarioexcursion", "motivoanulacion");
        }
    }
}
