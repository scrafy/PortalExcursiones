namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changecontrasenafield : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.usuario", name: "contrasena", newName: "PasswordHash");
            AlterColumn("dbo.usuario", "PasswordHash", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.usuario", "PasswordHash", c => c.String(nullable: false, unicode: false, storeType: "text"));
            RenameColumn(table: "dbo.usuario", name: "PasswordHash", newName: "contrasena");
        }
    }
}
