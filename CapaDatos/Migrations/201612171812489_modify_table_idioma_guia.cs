namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify_table_idioma_guia : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.idioma_guia", newName: "idioma_exact");
            DropForeignKey("dbo.calendarioexcursion_guia", "guia_id", "dbo.guia");
            DropForeignKey("dbo.idioma_guia", "guia_id", "dbo.guia");
            DropForeignKey("dbo.guia", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion");
            DropIndex("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha" });
            DropIndex("dbo.calendarioexcursion_guia", new[] { "guia_id" });
            DropIndex("dbo.guia", new[] { "usuario_id" });
            DropIndex("dbo.idioma_exact", new[] { "guia_id" });
            DropPrimaryKey("dbo.idioma_exact");
            AddColumn("dbo.idioma_exact", "exact_id", c => c.Long(nullable: false, storeType: "int unsigned"));
            AddColumn("dbo.idioma_exact", "guia", c => c.Boolean(nullable: false));
            AddColumn("dbo.idioma_exact", "guia_escrita", c => c.Boolean(nullable: false));
            AddColumn("dbo.idioma_exact", "audio_auricular", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.idioma_exact", new[] { "idioma_id", "exact_id" });
            CreateIndex("dbo.idioma_exact", "exact_id");
            AddForeignKey("dbo.idioma_exact", "exact_id", "dbo.excursionactividad", "exact_id");
            DropColumn("dbo.idioma_exact", "guia_id");
            DropTable("dbo.calendarioexcursion_guia");
            DropTable("dbo.guia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.guia",
                c => new
                    {
                        usuario_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        nota = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.usuario_id);
            
            CreateTable(
                "dbo.calendarioexcursion_guia",
                c => new
                    {
                        exact_id = c.Long(nullable: false, storeType: "uint"),
                        fecha = c.DateTime(nullable: false, precision: 0),
                        guia_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.exact_id, t.fecha, t.guia_id });
            
            AddColumn("dbo.idioma_exact", "guia_id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            DropForeignKey("dbo.idioma_exact", "exact_id", "dbo.excursionactividad");
            DropIndex("dbo.idioma_exact", new[] { "exact_id" });
            DropPrimaryKey("dbo.idioma_exact");
            DropColumn("dbo.idioma_exact", "audio_auricular");
            DropColumn("dbo.idioma_exact", "guia_escrita");
            DropColumn("dbo.idioma_exact", "guia");
            DropColumn("dbo.idioma_exact", "exact_id");
            AddPrimaryKey("dbo.idioma_exact", new[] { "idioma_id", "guia_id" });
            CreateIndex("dbo.idioma_exact", "guia_id");
            CreateIndex("dbo.guia", "usuario_id");
            CreateIndex("dbo.calendarioexcursion_guia", "guia_id");
            CreateIndex("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha" });
            AddForeignKey("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha" }, "dbo.calendarioexcursion", new[] { "exact_id", "fecha" });
            AddForeignKey("dbo.guia", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.idioma_guia", "guia_id", "dbo.guia", "usuario_id");
            AddForeignKey("dbo.calendarioexcursion_guia", "guia_id", "dbo.guia", "usuario_id");
            RenameTable(name: "dbo.idioma_exact", newName: "idioma_guia");
        }
    }
}
