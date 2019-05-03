namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao800 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historias", "DataTermino", c => c.DateTime());
            AddColumn("dbo.Historias", "Observacao", c => c.String());
            AddColumn("dbo.Historias", "IdDesenvolvedorResponsavel", c => c.Int());
            AddColumn("dbo.Historias", "IdCriadorResponsavel", c => c.Int(nullable: false));
            AddColumn("dbo.Historias", "IdProjeto", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "Nivel", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "DataCadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "DataCadastro");
            DropColumn("dbo.Usuarios", "Nivel");
            DropColumn("dbo.Historias", "IdProjeto");
            DropColumn("dbo.Historias", "IdCriadorResponsavel");
            DropColumn("dbo.Historias", "IdDesenvolvedorResponsavel");
            DropColumn("dbo.Historias", "Observacao");
            DropColumn("dbo.Historias", "DataTermino");
        }
    }
}
