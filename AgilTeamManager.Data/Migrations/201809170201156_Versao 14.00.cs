namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1400 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historias", "FotoDesenvolvedor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Historias", "FotoDesenvolvedor");
        }
    }
}
