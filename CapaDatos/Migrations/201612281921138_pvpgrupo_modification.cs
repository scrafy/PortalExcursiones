namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pvpgrupo_modification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.excursionactividad", "precioporgrupo", c => c.Boolean(nullable: false));
            AddColumn("dbo.preciotemporada", "costegrupo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.preciotemporada", "netogrupo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.preciotemporada", "pvpgrupo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.preciotemporada", "pvpgrupo");
            DropColumn("dbo.preciotemporada", "netogrupo");
            DropColumn("dbo.preciotemporada", "costegrupo");
            DropColumn("dbo.excursionactividad", "precioporgrupo");
        }
    }
}
