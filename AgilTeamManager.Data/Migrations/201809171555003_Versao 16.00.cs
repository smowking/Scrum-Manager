namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1600 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HistoriaHistoricoes", "SprintId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HistoriaHistoricoes", "SprintId", c => c.Int(nullable: false));
        }
    }
}
