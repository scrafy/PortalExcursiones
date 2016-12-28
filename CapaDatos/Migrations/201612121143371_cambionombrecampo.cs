namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambionombrecampo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.idioma", new[] { "nombre" });
            AddColumn("dbo.idioma", "lenguage", c => c.String(nullable: false, maxLength: 100, unicode: false));
            CreateIndex("dbo.idioma", "lenguage", unique: true);
            DropColumn("dbo.idioma", "nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.idioma", "nombre", c => c.String(nullable: false, maxLength: 100, unicode: false));
            DropIndex("dbo.idioma", new[] { "lenguage" });
            DropColumn("dbo.idioma", "lenguage");
            CreateIndex("dbo.idioma", "nombre", unique: true);
        }
    }
}
