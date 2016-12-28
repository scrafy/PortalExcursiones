namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codigoqr_campo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.reserva", "codigoqr", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.reserva", "codigoqr");
        }
    }
}
