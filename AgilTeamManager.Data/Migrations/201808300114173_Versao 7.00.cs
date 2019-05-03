namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao700 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SprintAuxiliars", "HistoriaId", "dbo.Historias");
            DropForeignKey("dbo.SprintAuxiliars", "SprintId", "dbo.Sprints");
            DropIndex("dbo.SprintAuxiliars", new[] { "HistoriaId" });
            DropIndex("dbo.SprintAuxiliars", new[] { "SprintId" });
            AlterColumn("dbo.SprintAuxiliars", "HistoriaId", c => c.Int(nullable: false));
            AlterColumn("dbo.SprintAuxiliars", "SprintId", c => c.Int(nullable: false));
            CreateIndex("dbo.SprintAuxiliars", "HistoriaId");
            CreateIndex("dbo.SprintAuxiliars", "SprintId");
            AddForeignKey("dbo.SprintAuxiliars", "HistoriaId", "dbo.Historias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SprintAuxiliars", "SprintId", "dbo.Sprints", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SprintAuxiliars", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.SprintAuxiliars", "HistoriaId", "dbo.Historias");
            DropIndex("dbo.SprintAuxiliars", new[] { "SprintId" });
            DropIndex("dbo.SprintAuxiliars", new[] { "HistoriaId" });
            AlterColumn("dbo.SprintAuxiliars", "SprintId", c => c.Int());
            AlterColumn("dbo.SprintAuxiliars", "HistoriaId", c => c.Int());
            CreateIndex("dbo.SprintAuxiliars", "SprintId");
            CreateIndex("dbo.SprintAuxiliars", "HistoriaId");
            AddForeignKey("dbo.SprintAuxiliars", "SprintId", "dbo.Sprints", "Id");
            AddForeignKey("dbo.SprintAuxiliars", "HistoriaId", "dbo.Historias", "Id");
        }
    }
}
