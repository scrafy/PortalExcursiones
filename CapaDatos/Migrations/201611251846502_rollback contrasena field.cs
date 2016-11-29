namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollbackcontrasenafield : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.usuario", name: "PasswordHash", newName: "contrasena");
            AlterColumn("dbo.usuario", "contrasena", c => c.String(nullable: false, unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.usuario", "contrasena", c => c.String(unicode: false));
            RenameColumn(table: "dbo.usuario", name: "contrasena", newName: "PasswordHash");
        }
    }
}
