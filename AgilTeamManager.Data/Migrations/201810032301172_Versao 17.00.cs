namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1700 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SprintId = c.Int(),
                        DataEvento = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Fixo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Eventoes");
        }
    }
}
