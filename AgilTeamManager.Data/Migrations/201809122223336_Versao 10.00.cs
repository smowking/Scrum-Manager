namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1000 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Foto", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Foto", c => c.Binary());
        }
    }
}
