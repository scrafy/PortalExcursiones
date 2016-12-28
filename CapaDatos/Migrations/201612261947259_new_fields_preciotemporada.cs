namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_fields_preciotemporada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.reservaexcursionactividad", "numjuniors", c => c.Byte(nullable: false));
            AddColumn("dbo.reservaexcursionactividad", "numseniors", c => c.Byte(nullable: false));
            AddColumn("dbo.preciotemporada", "pvpjunior", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.preciotemporada", "pvpsenior", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.preciotemporada", "costejunior", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.preciotemporada", "costesenior", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.preciotemporada", "netojunior", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.preciotemporada", "netosenior", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.preciotemporada", "netosenior");
            DropColumn("dbo.preciotemporada", "netojunior");
            DropColumn("dbo.preciotemporada", "costesenior");
            DropColumn("dbo.preciotemporada", "costejunior");
            DropColumn("dbo.preciotemporada", "pvpsenior");
            DropColumn("dbo.preciotemporada", "pvpjunior");
            DropColumn("dbo.reservaexcursionactividad", "numseniors");
            DropColumn("dbo.reservaexcursionactividad", "numjuniors");
        }
    }
}
