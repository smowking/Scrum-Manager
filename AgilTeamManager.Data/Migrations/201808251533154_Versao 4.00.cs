namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao400 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historias", "Prioridade", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Historias", "Prioridade");
        }
    }
}
