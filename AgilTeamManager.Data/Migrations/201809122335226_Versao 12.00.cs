namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1200 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "ProfilePicture", c => c.Binary());
            DropColumn("dbo.Usuarios", "Foto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Foto", c => c.String());
            DropColumn("dbo.Usuarios", "ProfilePicture");
        }
    }
}
