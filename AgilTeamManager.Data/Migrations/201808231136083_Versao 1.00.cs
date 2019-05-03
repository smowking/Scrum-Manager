namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Historias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Descricao = c.String(),
                        DataAbertura = c.DateTime(nullable: false),
                        IdRecurso = c.Int(nullable: false),
                        ColunaId = c.Int(nullable: false),
                        Recurso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScrumBoardColunas", t => t.ColunaId, cascadeDelete: true)
                .ForeignKey("dbo.Recursoes", t => t.Recurso_Id)
                .Index(t => t.ColunaId)
                .Index(t => t.Recurso_Id);
            
            CreateTable(
                "dbo.ScrumBoardColunas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdHistoria = c.Int(nullable: false),
                        Descricao = c.String(),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Pontos = c.Int(nullable: false),
                        Historia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Historias", t => t.Historia_Id)
                .Index(t => t.Historia_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "Historia_Id", "dbo.Historias");
            DropForeignKey("dbo.Historias", "Recurso_Id", "dbo.Recursoes");
            DropForeignKey("dbo.Historias", "ColunaId", "dbo.ScrumBoardColunas");
            DropIndex("dbo.Tarefas", new[] { "Historia_Id" });
            DropIndex("dbo.Historias", new[] { "Recurso_Id" });
            DropIndex("dbo.Historias", new[] { "ColunaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Recursoes");
            DropTable("dbo.ScrumBoardColunas");
            DropTable("dbo.Historias");
        }
    }
}
