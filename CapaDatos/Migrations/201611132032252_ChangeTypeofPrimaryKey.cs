namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeofPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.calendarioexcursion_guia", "guia_id", "dbo.guia");
            DropForeignKey("dbo.idioma_guia", "guia_id", "dbo.guia");
            DropForeignKey("dbo.cliente", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.colaborador", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.guia", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.proveedor", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.reserva", "cliente_id", "dbo.cliente");
            DropForeignKey("dbo.reserva", "colaborador_id", "dbo.colaborador");
            DropForeignKey("dbo.configuracion", "proveedor_id", "dbo.proveedor");
            DropForeignKey("dbo.reserva", "proveedor_id", "dbo.proveedor");
            DropIndex("dbo.configuracion", new[] { "proveedor_id" });
            DropIndex("dbo.calendarioexcursion_guia", new[] { "guia_id" });
            DropIndex("dbo.guia", new[] { "usuario_id" });
            DropIndex("dbo.idioma_guia", new[] { "guia_id" });
            DropIndex("dbo.cliente", new[] { "usuario_id" });
            DropIndex("dbo.reserva", new[] { "cliente_id" });
            DropIndex("dbo.reserva", new[] { "proveedor_id" });
            DropIndex("dbo.reserva", new[] { "colaborador_id" });
            DropIndex("dbo.colaborador", new[] { "usuario_id" });
            DropIndex("dbo.proveedor", new[] { "usuario_id" });
            DropPrimaryKey("dbo.calendarioexcursion_guia");
            DropPrimaryKey("dbo.guia");
            DropPrimaryKey("dbo.idioma_guia");
            DropPrimaryKey("dbo.usuario");
            DropPrimaryKey("dbo.cliente");
            DropPrimaryKey("dbo.colaborador");
            DropPrimaryKey("dbo.proveedor");
            AlterColumn("dbo.configuracion", "proveedor_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.calendarioexcursion_guia", "guia_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.guia", "usuario_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.idioma_guia", "guia_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.usuario", "id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.cliente", "usuario_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.reserva", "cliente_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.reserva", "proveedor_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.reserva", "colaborador_id", c => c.String(maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.colaborador", "usuario_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AlterColumn("dbo.proveedor", "usuario_id", c => c.String(nullable: false, maxLength: 128, storeType: "varchar(128)"));
            AddPrimaryKey("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha", "guia_id" });
            AddPrimaryKey("dbo.guia", "usuario_id");
            AddPrimaryKey("dbo.idioma_guia", new[] { "idioma_id", "guia_id" });
            AddPrimaryKey("dbo.usuario", "id");
            AddPrimaryKey("dbo.cliente", "usuario_id");
            AddPrimaryKey("dbo.colaborador", "usuario_id");
            AddPrimaryKey("dbo.proveedor", "usuario_id");
            CreateIndex("dbo.configuracion", "proveedor_id");
            CreateIndex("dbo.calendarioexcursion_guia", "guia_id");
            CreateIndex("dbo.guia", "usuario_id");
            CreateIndex("dbo.idioma_guia", "guia_id");
            CreateIndex("dbo.cliente", "usuario_id");
            CreateIndex("dbo.reserva", "cliente_id");
            CreateIndex("dbo.reserva", "proveedor_id");
            CreateIndex("dbo.reserva", "colaborador_id");
            CreateIndex("dbo.colaborador", "usuario_id");
            CreateIndex("dbo.proveedor", "usuario_id");
            AddForeignKey("dbo.calendarioexcursion_guia", "guia_id", "dbo.guia", "usuario_id");
            AddForeignKey("dbo.idioma_guia", "guia_id", "dbo.guia", "usuario_id");
            AddForeignKey("dbo.cliente", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.colaborador", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.guia", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.proveedor", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.reserva", "cliente_id", "dbo.cliente", "usuario_id");
            AddForeignKey("dbo.reserva", "colaborador_id", "dbo.colaborador", "usuario_id");
            AddForeignKey("dbo.configuracion", "proveedor_id", "dbo.proveedor", "usuario_id");
            AddForeignKey("dbo.reserva", "proveedor_id", "dbo.proveedor", "usuario_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.reserva", "proveedor_id", "dbo.proveedor");
            DropForeignKey("dbo.configuracion", "proveedor_id", "dbo.proveedor");
            DropForeignKey("dbo.reserva", "colaborador_id", "dbo.colaborador");
            DropForeignKey("dbo.reserva", "cliente_id", "dbo.cliente");
            DropForeignKey("dbo.proveedor", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.guia", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.colaborador", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.cliente", "usuario_id", "dbo.usuario");
            DropForeignKey("dbo.idioma_guia", "guia_id", "dbo.guia");
            DropForeignKey("dbo.calendarioexcursion_guia", "guia_id", "dbo.guia");
            DropIndex("dbo.proveedor", new[] { "usuario_id" });
            DropIndex("dbo.colaborador", new[] { "usuario_id" });
            DropIndex("dbo.reserva", new[] { "colaborador_id" });
            DropIndex("dbo.reserva", new[] { "proveedor_id" });
            DropIndex("dbo.reserva", new[] { "cliente_id" });
            DropIndex("dbo.cliente", new[] { "usuario_id" });
            DropIndex("dbo.idioma_guia", new[] { "guia_id" });
            DropIndex("dbo.guia", new[] { "usuario_id" });
            DropIndex("dbo.calendarioexcursion_guia", new[] { "guia_id" });
            DropIndex("dbo.configuracion", new[] { "proveedor_id" });
            DropPrimaryKey("dbo.proveedor");
            DropPrimaryKey("dbo.colaborador");
            DropPrimaryKey("dbo.cliente");
            DropPrimaryKey("dbo.usuario");
            DropPrimaryKey("dbo.idioma_guia");
            DropPrimaryKey("dbo.guia");
            DropPrimaryKey("dbo.calendarioexcursion_guia");
            AlterColumn("dbo.proveedor", "usuario_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.colaborador", "usuario_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.reserva", "colaborador_id", c => c.Long(storeType: "uint"));
            AlterColumn("dbo.reserva", "proveedor_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.reserva", "cliente_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.cliente", "usuario_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.usuario", "id", c => c.Long(nullable: false, identity: true, storeType: "uint"));
            AlterColumn("dbo.idioma_guia", "guia_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.guia", "usuario_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.calendarioexcursion_guia", "guia_id", c => c.Long(nullable: false, storeType: "uint"));
            AlterColumn("dbo.configuracion", "proveedor_id", c => c.Long(nullable: false, storeType: "uint"));
            AddPrimaryKey("dbo.proveedor", "usuario_id");
            AddPrimaryKey("dbo.colaborador", "usuario_id");
            AddPrimaryKey("dbo.cliente", "usuario_id");
            AddPrimaryKey("dbo.usuario", "id");
            AddPrimaryKey("dbo.idioma_guia", new[] { "idioma_id", "guia_id" });
            AddPrimaryKey("dbo.guia", "usuario_id");
            AddPrimaryKey("dbo.calendarioexcursion_guia", new[] { "exact_id", "fecha", "guia_id" });
            CreateIndex("dbo.proveedor", "usuario_id");
            CreateIndex("dbo.colaborador", "usuario_id");
            CreateIndex("dbo.reserva", "colaborador_id");
            CreateIndex("dbo.reserva", "proveedor_id");
            CreateIndex("dbo.reserva", "cliente_id");
            CreateIndex("dbo.cliente", "usuario_id");
            CreateIndex("dbo.idioma_guia", "guia_id");
            CreateIndex("dbo.guia", "usuario_id");
            CreateIndex("dbo.calendarioexcursion_guia", "guia_id");
            CreateIndex("dbo.configuracion", "proveedor_id");
            AddForeignKey("dbo.reserva", "proveedor_id", "dbo.proveedor", "usuario_id");
            AddForeignKey("dbo.configuracion", "proveedor_id", "dbo.proveedor", "usuario_id");
            AddForeignKey("dbo.reserva", "colaborador_id", "dbo.colaborador", "usuario_id");
            AddForeignKey("dbo.reserva", "cliente_id", "dbo.cliente", "usuario_id");
            AddForeignKey("dbo.proveedor", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.guia", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.colaborador", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.cliente", "usuario_id", "dbo.usuario", "id");
            AddForeignKey("dbo.idioma_guia", "guia_id", "dbo.guia", "usuario_id");
            AddForeignKey("dbo.calendarioexcursion_guia", "guia_id", "dbo.guia", "usuario_id");
        }
    }
}
