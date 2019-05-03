namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao500 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScrumBoardColunas", "Ordem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScrumBoardColunas", "Ordem");
        }
    }
}
