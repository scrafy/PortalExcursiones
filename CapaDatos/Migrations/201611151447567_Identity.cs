namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.claim",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        usuario_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        tipo = c.String(maxLength: 255, unicode: false),
                        valor = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.usuario", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.login",
                c => new
                    {
                        proveedor = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        key = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        usuario_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.proveedor, t.key, t.usuario_id })
                .ForeignKey("dbo.usuario", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.usuario_rol",
                c => new
                    {
                        usuario_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        role_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.usuario_id, t.role_id })
                .ForeignKey("dbo.usuario", t => t.usuario_id)
                .ForeignKey("dbo.rol", t => t.role_id)
                .Index(t => t.usuario_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.rol",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        nombre = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.nombre, unique: true, name: "RoleNameIndex");
            
            AddColumn("dbo.usuario", "mail", c => c.String(nullable: false, maxLength: 60, unicode: false));
            AddColumn("dbo.usuario", "username", c => c.String(nullable: false, maxLength: 60, unicode: false));
            AddColumn("dbo.usuario", "confirmacionemail", c => c.Boolean(nullable: false));
            AddColumn("dbo.usuario", "contrasena", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AddColumn("dbo.usuario", "securitystamp", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.usuario", "telefono", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AddColumn("dbo.usuario", "confirmaciontelefono", c => c.Boolean(nullable: false));
            AddColumn("dbo.usuario", "twofactorenabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.usuario", "lockoutenddateutc", c => c.DateTime(precision: 0));
            AddColumn("dbo.usuario", "lockoutenabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.usuario", "numaccesosfallidos", c => c.Int(nullable: false));
            CreateIndex("dbo.usuario", "mail", unique: true);
            CreateIndex("dbo.usuario", "username", unique: true);
            DropColumn("dbo.usuario", "email");
            DropColumn("dbo.usuario", "telefono1");
            DropColumn("dbo.usuario", "telefono2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.usuario", "telefono2", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.usuario", "telefono1", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AddColumn("dbo.usuario", "email", c => c.String(nullable: false, maxLength: 60, unicode: false));
            DropForeignKey("dbo.usuario_rol", "role_id", "dbo.rol");
            DropForeignKey("dbo.usuario_rol", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.login", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.claim", "usuario_id", "dbo.usuario");
            DropIndex("dbo.rol", "RoleNameIndex");
            DropIndex("dbo.usuario_rol", new[] { "role_id" });
            DropIndex("dbo.usuario_rol", new[] { "usuario_id" });
            DropIndex("dbo.login", new[] { "usuario_id" });
            DropIndex("dbo.claim", new[] { "usuario_id" });
            DropIndex("dbo.usuario", new[] { "username" });
            DropIndex("dbo.usuario", new[] { "mail" });
            DropColumn("dbo.usuario", "numaccesosfallidos");
            DropColumn("dbo.usuario", "lockoutenabled");
            DropColumn("dbo.usuario", "lockoutenddateutc");
            DropColumn("dbo.usuario", "twofactorenabled");
            DropColumn("dbo.usuario", "confirmaciontelefono");
            DropColumn("dbo.usuario", "telefono");
            DropColumn("dbo.usuario", "securitystamp");
            DropColumn("dbo.usuario", "contrasena");
            DropColumn("dbo.usuario", "confirmacionemail");
            DropColumn("dbo.usuario", "username");
            DropColumn("dbo.usuario", "mail");
            DropTable("dbo.rol");
            DropTable("dbo.usuario_rol");
            DropTable("dbo.login");
            DropTable("dbo.claim");
        }
    }
}
