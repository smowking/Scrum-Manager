namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao600 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SprintAuxiliars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HistoriaId = c.Int(),
                        SprintId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Historias", t => t.HistoriaId)
                .ForeignKey("dbo.Sprints", t => t.SprintId)
                .Index(t => t.HistoriaId)
                .Index(t => t.SprintId);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SprintAuxiliars", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.SprintAuxiliars", "HistoriaId", "dbo.Historias");
            DropIndex("dbo.SprintAuxiliars", new[] { "SprintId" });
            DropIndex("dbo.SprintAuxiliars", new[] { "HistoriaId" });
            DropTable("dbo.Sprints");
            DropTable("dbo.SprintAuxiliars");
        }
    }
}
