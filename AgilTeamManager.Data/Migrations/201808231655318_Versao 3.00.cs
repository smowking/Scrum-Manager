namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao300 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Historias", "ScrumBoardColunasId", "dbo.ScrumBoardColunas");
            DropIndex("dbo.Historias", new[] { "ScrumBoardColunasId" });
            RenameColumn(table: "dbo.Historias", name: "Recurso_Id", newName: "RecursoId");
            RenameIndex(table: "dbo.Historias", name: "IX_Recurso_Id", newName: "IX_RecursoId");
            AlterColumn("dbo.Historias", "ScrumBoardColunasId", c => c.Int());
            CreateIndex("dbo.Historias", "ScrumBoardColunasId");
            AddForeignKey("dbo.Historias", "ScrumBoardColunasId", "dbo.ScrumBoardColunas", "Id");
            DropColumn("dbo.Historias", "Numero");
            DropColumn("dbo.Historias", "IdRecurso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Historias", "IdRecurso", c => c.Int(nullable: false));
            AddColumn("dbo.Historias", "Numero", c => c.String());
            DropForeignKey("dbo.Historias", "ScrumBoardColunasId", "dbo.ScrumBoardColunas");
            DropIndex("dbo.Historias", new[] { "ScrumBoardColunasId" });
            AlterColumn("dbo.Historias", "ScrumBoardColunasId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Historias", name: "IX_RecursoId", newName: "IX_Recurso_Id");
            RenameColumn(table: "dbo.Historias", name: "RecursoId", newName: "Recurso_Id");
            CreateIndex("dbo.Historias", "ScrumBoardColunasId");
            AddForeignKey("dbo.Historias", "ScrumBoardColunasId", "dbo.ScrumBoardColunas", "Id", cascadeDelete: true);
        }
    }
}
