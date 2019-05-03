namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao900 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Foto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Foto");
        }
    }
}
