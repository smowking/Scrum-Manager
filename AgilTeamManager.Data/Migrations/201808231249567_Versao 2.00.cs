namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao200 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Historias", name: "ColunaId", newName: "ScrumBoardColunasId");
            RenameIndex(table: "dbo.Historias", name: "IX_ColunaId", newName: "IX_ScrumBoardColunasId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Historias", name: "IX_ScrumBoardColunasId", newName: "IX_ColunaId");
            RenameColumn(table: "dbo.Historias", name: "ScrumBoardColunasId", newName: "ColunaId");
        }
    }
}
