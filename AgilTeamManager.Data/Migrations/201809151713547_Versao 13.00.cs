namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1300 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configuracaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lingua = c.String(),
                        DuracaoDiasSprint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configuracaos");
        }
    }
}
