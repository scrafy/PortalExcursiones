namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamefototable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.foto", newName: "fotoconfiguracion");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.fotoconfiguracion", newName: "foto");
        }
    }
}
